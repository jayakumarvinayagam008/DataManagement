

$(document).ready(function (eve) {
    var tagsContainer = [];
    var tags = [];
    if ($('#hdnB2BTags').val() !== undefined) {
        tags = JSON.parse($('#hdnB2BTags').val());
    }

    $.each(tags, function (index, value) {
        title = $.trim(value);
        var country = { 'id': value.Id, 'title': value.Title };
        tagsContainer.push(country);
    });
    //console.log(tagsContainer);
    $('#b2btags').selectize({
        maxItems: null,
        valueField: 'id',
        labelField: 'title',
        searchField: 'title',
        options: tagsContainer,
        create: false
    });

    $('#btnBusinessToBusinessSearch').on('click', function (eve) {
             
        var cities = $('#b2bCityId').val();
        var states = $('#b2bStateId').val();
        var countries = $('#b2bCuntryId').val();
        var area = $('#b2bAreaId').val();
        var destinations = $('#b2bDestinationId').val();
        var businessCategory = $('#b2bBusinessCategoryId').val();
        var tags = $('#b2btags').val().split(',');
        if (cities !== null
            || states !== null
            || countries !== null
            || area !== null
            || destinations !== null
            || businessCategory !== null
            || tags !== null) {

            var b2bSearch = {
                'Cities': cities,
                'Tags': tags,
                'Contries': countries,
                'States': states,
                'Area': area,
                'Designation': destinations,
                'BusinessCategoryId': businessCategory
            };
            console.log(JSON.stringify(b2bSearch));

            $.ajax({
                url: '/Home/BusinessToBusinessSearch/',
                type: 'post',
                dataType: 'json',
                data: { business2Business: b2bSearch },
                success: function (data) {
                    UpdateB2BDashBoard(data);
                }
            });
        } else {
            alert('selectedCities');
        }
    });
    
});

function UpdateB2BDashBoard(customerData) {
    console.log(JSON.stringify(customerData));
    $('#dashBoardb2bItem').empty();
    $('#spnb2bTotal').text(customerData.total);
    $('#spnb2bSearchTotal').text(customerData.searchCount);
    $('#downloadb2bLink').val(customerData.downloadLink);

    var listItems = '';
    for (var key in customerData) {
        if (customerData.hasOwnProperty(key)) {

            if (b2CDashBoardItem[key] !== null
                && b2CDashBoardItem[key] !== undefined
                && b2CDashBoardItem[key] !== 'undefined') {
                $('#dashBoardb2bItem').append(ConstructDashboardItem(b2CDashBoardItem[key], customerData[key]));
            }
        }
    }
    $('#dashboardb2bBlock').show();

}
var b2CDashBoardItem = {
    'companyName': 'Company Name',
    'add1': 'Address1',
    'add2': 'Address2',
    'city': 'City',
    'area': 'Area',
    'pincode': 'Pincode',
    'state': 'State',
    'phoneNew': 'Phone New',
    'mobileNew': 'Mobile New',
    'phone1': 'Phone1',
    'phone2': 'Phone2',
    'mobile1': 'Mobile1',
    'mobile2': 'Mobile2',
    'fax': 'Fax',
    'email': 'Email',
    'email1': 'Email1',
    'web': 'Web',
    'contactPerson': 'Contact Person',
    'designation': 'Designation',
    'designation1': 'Designation1',
    'contactperson1': 'Contact Person1',
    'estYear': 'Est Year',
    'categoryId': 'Category Id',
    'landMark': 'Land Mark',
    'noOfEmp': 'Number Of Employee',
    'country': 'Country'
};
function ConstructDashboardItem(name, value) {
    return '<li  class="list-group-item d-flex justify-content-between align-items-center"><span class="caption">' + name + '</span><span class="badge badge-primary badge-pill">' + value.toFixed(2) + '%</span></li >';
}
$("#btnb2bDownloadExcel").on('click', function (eve) {
    var $fileName = $('#downloadb2bLink').val();
    if ($fileName !== '') {
        window.location = '/Home/Export/?fileName=' + $fileName + '&type=xlsx&templateType=0';

    } else {
        alert('file does not exist');
    }

});