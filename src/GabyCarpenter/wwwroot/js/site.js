﻿// Write your Javascript code.

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
    
    $('#clearFilter').click(function () { $("#tags").val([]); $("#colors").val([]);$("#inStock").val(["yes","no"]);$("#searchForm").ajaxSubmit(options); });
});

// post-submit callback 
function showResponse(json, statusText, xhr, $form) {
    // Hide all items divs
    $("[id^=item_]").hide();

    // display those returned from search
    json.items.forEach(function(id){
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

    //var addresses = ['הרצל  26 ירושלים','אלנבי 55'];

    //setMapMarkers(addresses);
    
});

function setMapMarkers(addresses) {
    for (var x = 0; x < addresses.length; x++) {
        $.getJSON('http://maps.googleapis.com/maps/api/geocode/json?address=' + addresses[x] + '&sensor=false', null, function (data) {
            var p = data.results[0].geometry.location
            var latlng = new google.maps.LatLng(p.lat, p.lng);
            new google.maps.Marker({
                position: latlng,
                map: map
            });

        });
    }
}
