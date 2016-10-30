// Write your Javascript code.

// Ajax submit when a change to the filter is made
$(document).ready(function () {
    var options = {
        target: '#',   // target element(s) to be updated with server response 
        success: showResponse,  // post-submit callback 
        dataType: "json"
    };

    // bind to the selects change event 
    $('#tags').change(function () { $("#searchForm").ajaxSubmit(options); });
    $('#colors').change(function () { $("#searchForm").ajaxSubmit(options); });
    $('#inStock').change(function () { $("#searchForm").ajaxSubmit(options); });

    $('#clearFilter').click(function () { $("#tags").val([]); $("#colors").val([]); $("#inStock").val(["yes", "no"]); $("#searchForm").ajaxSubmit(options); });

    //popover1
    setTimeout(function () {
        var addressesTds = $("[id^=address_td_]");
        addressesTds.each(function () {
            var tdObj = this;
            var address = $(this).attr("data-address")
           
            $.getJSON('http://maps.googleapis.com/maps/api/geocode/json?address=' + address + '&sensor=false', null, function (data) {
                var p = data.results[0].geometry.location

                $.getJSON("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(SELECT%20woeid%20FROM%20geo.places%20WHERE%20text%3D%22(" + p.lat + "%2C" + p.lng + ")%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys", null, function (data) {

                    $(tdObj).popover({ title: "Dear distributor", content: "Wheather in delivary area is: " + data.query.results.channel.item.condition.text + "\n(" + data.query.results.channel.item.title + ")", trigger: "hover" });

                });
            });
        })
    }, 100);
});

// post-submit callback 
function showResponse(json, statusText, xhr, $form) {
    // Hide all items divs
    $("[id^=item_]").hide();

    // display those returned from search
    json.items.forEach(function (id) {
        $("#item_" + id).show();
    });

    // EmptyColorsFilter
    $("#colors").empty();
    $.each(json.colors, function (index, value) {
        $('#colors')
            .append($("<option></option>")
                       .text(value).selected(true));
    });

    // EmptyTagsFilter
    $("#tags").empty();
    $.each(json.tags, function (index, value) {
        $('#tags')
            .append($("<option></option>")
                       .text(value).selected(true));
    });

}

var map;
$(document).ready(function () {

    var elevator;
    var myOptions = {
        zoom: 8,
        center: new google.maps.LatLng(32, 35),
        mapTypeId: 'roadmap'
    };
    map = new google.maps.Map($('#map_canvas')[0], myOptions);
    //setMapMarkers(addresses);

});

function setMapMarkers(addresses) {

    var bounds = new google.maps.LatLngBounds();

    for (var x = 0; x < addresses.length; x++) {
        $.getJSON('http://maps.googleapis.com/maps/api/geocode/json?address=' + addresses[x] + '&sensor=false', null, function (data) {
            var p = data.results[0].geometry.location
            var latlng = new google.maps.LatLng(p.lat, p.lng);
            new google.maps.Marker({
                position: latlng,
                map: map
            });
            bounds.extend(latlng);
        });
    }
    map.fitBounds(bounds);
}

function getWeather() {
    return "cloudy";
}