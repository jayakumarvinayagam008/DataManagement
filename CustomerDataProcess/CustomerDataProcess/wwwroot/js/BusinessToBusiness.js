$(window).on('load', function () {
    // code here
    $("#divLoading").hide();
    $.fn.dataTable.ext.search.push(

        function (setting, data, dataIndex) {
            var countries = data[26] || '';
            var selectedCountry = $('#Filter_CountryId').val() || [];
            var matchedItems = [];
            var result = $.grep(selectedCountry, function (n, i) {
                if (countries.indexOf(n) > -1) {
                    matchedItems.push(n);
                }
            });
            if (selectedCountry != null && selectedCountry.length === 0 || matchedItems.length > 0) {
                return true;
            }
            return false;
        },
        function (setting, data, dataIndex) {
            var cities = data[4] || '';
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
        },
        function (settings, data, dataIndex) {
            var businesscategory = data[23] || '';
            var selectedBusinessCategory = $('#Filter_BusinessCategoryId').val() || [];
            var matchedItems = [];
            var result = $.grep(selectedBusinessCategory, function (n, i) {
                if (businesscategory.indexOf(n) > -1) {
                    matchedItems.push(n);
                }
            });
            if (selectedBusinessCategory != null && selectedBusinessCategory.length === 0 || matchedItems.length > 0) {
                return true;
            }
            return false
        },
        function (setting, data, dataIndex) {
            var state = data[7] || '';
            var selectedState = $('#Filter_StateId').val() || [];
            var matchedItems = [];
            var result = $.grep(selectedState, function (n, i) {
                if (state.indexOf(n) > -1) {
                    matchedItems.push(n);
                }
            });
            if (selectedState != null && selectedState.length === 0 || matchedItems.length > 0) {
                return true;
            }
            return false;
        },
        function (setting, data, dataIndex) {
            var area = data[5] || '';
            var selectedArea = $('#Filter_AreaId').val() || [];
            console.log(selectedArea);
            var matchedItems = [];
            var result = $.grep(selectedArea, function (n, i) {
                if (area.indexOf(n) > -1) {
                    matchedItems.push(n);
                }
            });
            if (selectedArea != null && selectedArea.length === 0 || matchedItems.length > 0) {
                return true;
            }
            return false;
        },
        function (setting, data, dataIndex) {
            var designation = data[19] || '';
            var selectedDesignation = $('#Filter_DesiginationId').val() || [];
            var matchedItems = [];
            var result = $.grep(selectedDesignation, function (n, i) {
                if (designation.indexOf(n) > -1) {
                    matchedItems.push(n);
                }
            });
            if (selectedDesignation != null && selectedDesignation.length === 0 || matchedItems.length > 0) {
                return true;
            }
            return false;
        }
    );
});

$(document).ready(function (eve) {
    $("#btnApply").on('click', function (eve) {
        business2BusinessTable.draw();
    });
});