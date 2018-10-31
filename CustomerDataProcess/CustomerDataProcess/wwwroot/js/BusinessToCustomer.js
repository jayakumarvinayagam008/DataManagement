$(document).ready(function (eve) {

    var tagsContainer = [];
    var tags = [];
    if ($('#hdnB2CTags').val() !== undefined) {
        tags = JSON.parse($('#hdnB2CTags').val());
    }

    $.each(tags, function (index, value) {
        title = $.trim(value);
        var country = { 'id': value.Id, 'title': value.Title };
        tagsContainer.push(country);
    });

    $('#b2ctags').selectize({
        maxItems: null,
        valueField: 'id',
        labelField: 'title',
        searchField: 'title',
        options: tagsContainer,
        create: false
    });

    $('#btnBusinessToCustomerSearch').on('click', function (eve) {

        var cities = $('#b2cCityId').val();
        var states = $('#b2cStateId').val();
        var countries = $('#b2cCuntryId').val();
        var area = $('#b2cAreaId').val();
        var roles = $('#b2cRoleId').val();
        var ages = $('#b2cAgeId').val();
        var salaries = $('#b2cSalaryId').val();
        var expercince = $('#b2cExpercinceId').val();
        var tags = $('#b2ctags').val().split(',');
        if (cities !== null
            || states !== null
            || countries !== null
            || area !== null
            || roles !== null
            || ages !== null
            || salaries !== null
            || expercince !== null
            || tags !== null) {

            var b2CSearch = {
                'Cities': cities,
                'Tags': tags,
                'Contries': countries,
                'States': states,
                'Ages': ages,
                'Area': area,
                'Roles': roles,
                'Experience': expercince,
                'Salaries': salaries
            };

            $.ajax({
                url: '/Home/BusinessToCustomerSearch/',
                type: 'post',
                dataType: 'json',
                data: { customerDataSearch: b2CSearch },
                beforeSend: function (eve) {
                    $("#divLoading").show();
                },
                success: function (data) {
                    UpdateB2CDashBoard(data);
                },
                complete: function () {
                    $("#divLoading").hide();
                }
            });
        } else {
            alert('selectedCities');
        }
    });

    $("#btnb2cDownloadExport").on('click', function (eve) {
        var $fileName = $('#downloadb2cLink').val();
        if ($fileName !== '') {
            window.location = '/Home/Export/?fileName=' + $fileName + '&type=xlsx&templateType=1';

        } else {
            alert('file does not exist');
        }

    });
});
function UpdateB2CDashBoard(customerData) {
    $('#dashBoardb2cItem').empty();
    $('#spnb2cTotal').text(customerData.total);
    $('#spnb2cSearchTotal').text(customerData.searchCount);
    $('#downloadb2cLink').val(customerData.downloadLink);
    
    var listItems = '';
    for (var key in customerData) {
        if (customerData.hasOwnProperty(key)) {

            if (b2CDashBoardItem[key] !== null
                && b2CDashBoardItem[key] !== undefined
                && b2CDashBoardItem[key] !== 'undefined') {
                $('#dashBoardb2cItem').append(ConstructDashboardItem(b2CDashBoardItem[key], customerData[key]));
            }
        }
    }
    $('#dashboardb2cBlock').show();

}
var b2CDashBoardItem = {
    'name': 'Name',
    'dob': 'Dob',
    'qualification': 'Qualification',
    'experience': 'Experience',
    'employer': 'Employer',
    'keySkills': 'KeySkills',
    'location': 'Location',
    'roles': 'Roles',
    'industry': 'Industry',
    'address': 'Address',
    'address2': 'Address2',
    'email': 'Email',
    'phoneNew': 'PhoneNew',
    'mobileNew': 'MobileNew',
    'mobile2': 'Mobile2',
    'annualSalary': 'AnnualSalary',
    'pincode': 'Pincode',
    'area': 'Area',
    'city': 'City',
    'state': 'State',
    'country': 'Country',
    'network': 'Network',
    'gender': 'Gender',
    'caste': 'Caste'
};
function ConstructDashboardItem(name, value) {
    return '<li  class="list-group-item d-flex justify-content-between align-items-center"><span class="caption">' + name + '</span><span class="badge badge-primary badge-pill">' + value.toFixed(2) + '%</span></li >';
}