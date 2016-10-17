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
    $('#PriceRange').change(function () { $("#searchForm").ajaxSubmit(options); });
});

// post-submit callback 
function showResponse(json, statusText, xhr, $form) {
    // Hide all items divs
    $("[id^=item_]").hide();

    // display those returned from search
    for (var id in json) {
        $("#item_" + id).show();
    }
}