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