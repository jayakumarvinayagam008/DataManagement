$(window).on('load', function () {
    // code here
    $("#divLoading").hide();
    $.fn.dataTable.ext.search.push(
        function (setting, data, dataIndex) {
            var cities = data[8] || '';
            var selectedCities = $('#Filter_CityId').val() || [];
            var matchedItems = [];
            var result = $.grep(selectedCities, function (n, i) {
                if (cities.indexOf(n) > -1) {
                    matchedItems.push(n);
                }
            });
            if (selectedCities != null && selectedCities.length === 0 || matchedItems.length > 0) {
                return true;
            }
            return false;
        }
    );
});

$(document).ready(function (eve) {
    $("#btnCustomerFilterApply").on('click', function (eve) { 
        customerDataTable.draw();
    });
});