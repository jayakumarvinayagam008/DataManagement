// Write your JavaScript code.
$(document).ready(function (eve) {
   
    $("#divLoading").show();
    var tagsContainer = [];
    var tags = [];
    if ($('#hdnTags').val() !== undefined) {
        tags = JSON.parse($('#hdnTags').val());
    }   
    
    $.each(tags, function (index, value) {
        title = $.trim(value);
        var country = { 'id': value.Id, 'title': value.Title };
        tagsContainer.push(country);
    });

    $('#tags').selectize({
        maxItems: null,
        valueField: 'id',
        labelField: 'title',
        searchField: 'title',
        options: tagsContainer,
        create: false
    });

    $("#btnsample").on('click', function (eve) {
        var $selectedTypeId = parseInt($('#UploadTypeId').prop('selectedIndex'));
        if ($selectedTypeId === 0) {
            $('#sampleDownloadStatus').show();
            return 0;
        } else {
            $('#sampleDownloadStatus').hide();
        }
        window.location = '/Home/DownloadSampleTemplate/?templateId=' + $selectedTypeId;
    });

    $("#btnNumberLookUp").on('click', function (eve) {
        var fileName = $('#hndLookupId').val();
        window.location = '/Home/DownLoadNumberLookup/?fileName=' + fileName;
    });

    $("#btnCustomerDataSearch").on('click', function (eve) {
        var selectedCities = $('#cityId').val();
        var networks = $('#networkId').val();
        var dataQualities = $('#dataQualityId').val();
        var businessVerticalIds = $('#businessVerticalId').val();
        var customers = $('#customerId').val();
        var states = $('#stateId').val();
        var countries = $('#countryId').val();

        var tags = $('#tags').val().split(',');

        if (selectedCities !== null
            || networks !== null
            || dataQualities !== null
            || businessVerticalIds !== null
            || customerId !== null
            || states !== null
            || countries !== null
            || tags !== null && tags !== ''
        ) {
            var customerDataSearch = {
                'Cities': selectedCities,
                'DataQuantities': dataQualities,
                'Tags': tags,
                'Network': networks,
                'BusinessVertical': businessVerticalIds,
                'CustomerNames': customers,
                'Contries': countries,
                'States': states
            };

            $.ajax({
                url: '/Home/CustomerData/',
                type: 'post',
                dataType: 'json',
                data: { customerDataSearch: customerDataSearch },
                beforeSend: function (eve) {
                    $("#divLoading").show();  
                },
                success: function (data) {
                    UpdateDashBoard(data);
                },
                complete: function () {
                    $("#divLoading").hide();  
                }
            });
        } else {
            alert('selectedCities');
        }
    });
    $("#btnCustomerExcelExport").on('click', function (eve) {
        var $fileName = $('#downloadLink').val();
        if ($fileName !== '') {
            window.location = '/Home/Export/?fileName=' + $fileName +'&type=xlsx&templateType=2';
           
        } else {
            alert('file does not exist');
        }
        
    });

    $("#btnUserDataUpload").on('click', function (eve) {
        $("#divLoading").show();
        $('#frmUserDataForm').submit();
    });

    $("#btnNumberLookup").on('click', function (eve) {
        $("#divLoading").show();
        $('#frmNumberLookUp').submit();
    });

    
});

$(window).on('load', function () {
    $("#divLoading").hide();
});

//{"Cities":["Bangalore"],"DataQuantities":null,"Tags":"","Network":null,"BusinessVertical":null}
function UpdateDashBoard(customerData) {
    $('#dashBoardItem').empty();
    $('#spnTotal').text(customerData.total);
    $('#spnSearchTotal').text(customerData.searchCount);
    $('#downloadLink').val(customerData.downloadLink);

    var listItems = '';
    for (var key in customerData) {
        if (customerData.hasOwnProperty(key)) {

            if (dashBoardItem[key] !== null
                && dashBoardItem[key] !== undefined
                && dashBoardItem[key] !== 'undefined') {
                $('#dashBoardItem').append(ConstructDashboardItem(dashBoardItem[key], customerData[key]));
            }
        }
    }
    $('#dashboardBlock').show();
    
}
var dashBoardItem = {
    'city': 'City',
    'operator': 'Operator',
    'clientBusinessVertical': 'Client Business Vertical',
    'dbquality': 'DB Quality',
    'clientName': 'Client Name',
    'dateOfUse': 'Date Of Use',
    'numbers': 'Numbers',
    'stateCount': 'State',
    'countryCount':'Country'
};
function ConstructDashboardItem(name, value) {
    return '<li  class="list-group-item d-flex justify-content-between align-items-center"><span class="caption">' + name + '</span><span class="badge badge-primary badge-pill">' + value.toFixed(2) + '%</span></li >';
}
