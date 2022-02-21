

app.controller('SearchResultCtrl',
     function ParamsController($scope, $window, $routeParams, $window) {
         scope = $scope;

         scope = $scope;


         scope.all = false;
         $scope.sortType = 'SlNo'; // set the default sort type
         $scope.sortReverse = false;  // set the default sort order

         $scope.SelectedGov = "Select";
         $scope.SelectedGovId = '0';
         $scope.SelectedArea = "Select";
         $scope.SelectedAreaId = '0';
         $scope.SelectedStadium = "Select";

         $scope.SelectedTime = "";
         $scope.SelDt = "";

         $scope.SelectedStadiumId = $routeParams.selStadId;
         $scope.SelDt = $routeParams.selDate;
         $scope.myFav = 0;
         $scope.ShowPara = 'Images';

         var vm = this;

         vm.openModal = openModal;
         vm.closeModal = closeModal;

         initController();

         $scope.ClickFavorite = function () {

             if ($window.sessionStorage.getItem('userlogin') == 'true') {

                 $('#divmodalmsg2').hide();
                 $("#divmodalspin2").show();
                 $.ajax({
                     type: 'post',
                     url: 'MYMA.asmx/fn_InsertFavorite',
                     data: {
                         ls_euid: $window.sessionStorage.getItem('euid'),
                         li_stadid: $scope.SelectedStadiumId
                     },
                     dataType: 'json',
                     headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                     success: function (data, textStatus, jqXHR) {
                         //console.log($(".heart").hasClass("is-active"));
                         $(".heart").toggleClass("is-active");
                         $("#divmodalmsg2").show();
                         if ($(".heart").hasClass("is-active") == true) {
                             $('#divmodalmsg2').html('<div class="alert alert-info" style=""><button type="button" class="close" data-dismiss="alert"><i class="ace-icon fa fa-times"></i></button><strong>تم اضافة الملعب لقائمة مفضلتك  </strong> </div>');
                         } else {
                             $('#divmodalmsg2').html('<div class="alert alert-danger" style=""><button type="button" class="close" data-dismiss="alert"><i class="ace-icon fa fa-times"></i></button><strong>تم حدف الملعب من قائمة مفضلتك   </strong> </div>');
                         }
                         $('#divmodalspin2').hide(0)
                     }, error: function (data, ajaxOptions, thrownError) {
                         console.log(data);
                         scope.msg = data[0].message;
                         scope.$apply();
                         scope.MsgBox();
                         $('#divmodalspin2').hide(0)
                     }
                 });

             } else {
                 setTimeout(function () { window.location = "Login/SearchResult|" + $scope.SelectedStadiumId + "|" + $scope.SelDt; }, 500);
             }


         }

         $scope.changerating = function () {

             if ($window.sessionStorage.getItem('userlogin') == 'true') {

                 $('#divmodalmsg2').hide();
                 $("#divmodalspin2").show();
                 $.ajax({
                     type: 'post',
                     url: 'MYMA.asmx/fn_InsertRating',
                     data: {
                         ls_euid: $window.sessionStorage.getItem('euid'),
                         li_stadid: $scope.SelectedStadiumId,
                         li_rating: $scope.myRate
                     },
                     dataType: 'json',
                     headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                     success: function (data, textStatus, jqXHR) {
                         $("#divmodalmsg2").show();
                         $('#divmodalmsg2').html('<div class="alert alert-info" style=""><button type="button" class="close" data-dismiss="alert"><i class="ace-icon fa fa-times"></i></button><strong>شكرا لتقييمك </strong> </div>');
                         $scope.GetRating();
                         $('#divmodalspin2').hide(0)
                     }, error: function (data, ajaxOptions, thrownError) {
                         console.log(data);
                         scope.msg = data[0].message;
                         scope.$apply();
                         scope.MsgBox();
                         $('#divmodalspin2').hide(0)
                     }
                 });

             } else {
                 setTimeout(function () { window.location = "Login/SearchResult|" + $scope.SelectedStadiumId + "|" + $scope.SelDt; }, 500);
             }



         }


         $scope.GetRating = function () {
            
             var ls_userid = '';
             if ($window.sessionStorage.getItem('userlogin') == 'true') {
                 ls_userid = $window.sessionStorage.getItem('euid');
             } else {
                 ls_userid = '';
             }

             $("#divmodalspin").show();
             $.ajax({
                 type: 'post',
                 url: 'MYMA.asmx/Get_MYA_Maleabna_Rating',
                 data: {
                     ls_stadid: $scope.SelectedStadiumId,
                     ls_euid: ls_userid
                 },
                 dataType: 'json',
                 headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                 success: function (data, textStatus, jqXHR) {

                     $scope.ovRate = data[0].rating;
                     $scope.myRate = data[0].myrating;
                     $scope.myFav = data[0].fav;
                     
                     scope.$apply();
                     $('#divmodalspin').hide(0)
                     if (data[0].fav == '1') {
                         if ($(".heart").hasClass("is-active") == false) {
                             setTimeout(function () { $(".heart").toggleClass("is-active"); }, 1000);
                         }
                     }

                 }, error: function (data, ajaxOptions, thrownError) {
                     console.log(data);
                     scope.msg = data[0].message;
                     scope.$apply();
                     scope.MsgBox();
                     $('#divmodalspin').hide(0)
                 }
             });

         }

         function initController() {
             vm.bodyText = 'This text can be updated in modal 1';
         }

         function openModal(id) {
             ModalService.Open(id);
         }

         function closeModal(id) {
             ModalService.Close(id);
         }



         $scope.OnClickTab = function (ls_type) {             
            $scope.ShowPara = ls_type;            
         }

         scope.OnChangeDate = function () {
             
             $scope.LoadReport();
             $scope.CheckFullBlock();
             $scope.GetGovernorate();
             $scope.GetArea();
             $scope.GetStadium();
             $scope.GetTime();
         }


         $scope.CheckFullBlock = function () {

             $.ajax({
                 type: 'post',
                 url: 'MYMA.asmx/fn_CheckWholeSiteBlock',
                 data: {
                     ld_data: $scope.SelDt
                 },
                 dataType: 'json',
                 headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                 success: function (data, textStatus, jqXHR) {
                     if (data[0].Error == 'False') {
                         //setTimeout(function () { window.location = '#SiteBlock/' + data[0].DateFrm + ' To ' + data[0].DateTo; }, 500);
                         setTimeout(function () { window.location = 'SiteBlock/' + data[0].DisplayMsg; }, 500);
                     }

                     $('#cover-spin').hide(0)
                 }, error: function (data, ajaxOptions, thrownError) {
                     console.log(data);
                     scope.msg = data[0].message;
                     scope.$apply();
                     scope.MsgBox();
                     $('#cover-spin').hide(0)
                 }
             });
         }


         scope.OpenLocation = function (url) {

             $window.open(url, '_blank');

         }

         $scope.unCheck = function (lstime, detid) {

             angular.forEach($scope.dtReport, function (item) {
                 if (lstime != item.TimeSlot || detid == item.StadiumDetId) {
                     item.Selected = false;
                 }
             });
         };


         $scope.clickrating = function (rate) {
              
             $('#ratingModal').modal({
                 backdrop: 'static'
             });
             //$scope.ngval = rate;
             $scope.Rating = 'Average';
             //             console.log(rate);
             //$scope.$apply();
         };


         scope.OnClickSubmit = function () {

             $('#divmodalmsg').hide();
             $("#divmodalspin").show();

             var timeselect = false;
             angular.forEach($scope.dtReport, function (item) {
                 if (item.Selected == true) {
                     timeselect = true;
                     $scope.SelectedTime = item.TimeSlot;
                     $scope.SelectedTimeDetId = item.StadiumDetID;

                 }
             });

             if (timeselect == false) {

                 $('#divmodalmsg').html('<div class="alert alert-danger" style=""><button type="button" class="close" data-dismiss="alert"><i class="ace-icon fa fa-times"></i></button><strong>الرجاء اختيار الفترة الزمنية </strong> </div>');
                 $('#divmodalmsg').show();
                 $("#divmodalspin").hide();
                 return;
             }

             if ($window.sessionStorage.getItem('userlogin') == 'true') {

                 setTimeout(function () { window.location = "Booking/" + $scope.SelectedStadiumId + "/" + $scope.SelectedTimeDetId + "/" + $scope.SelectedTime + "/" + $scope.SelDt + "/0/Booking"; }, 500);
             } else {
                 setTimeout(function () { window.location = "Login/Booking|" + $scope.SelectedStadiumId + "|" + $scope.SelectedTimeDetId + "|" + $scope.SelectedTime + "|" + $scope.SelDt + "|0|Booking"; }, 500);
             }
         }


         scope.ReLoadReport = function () {
             scope.GetTimeSummary();
             scope.LoadReport();
             scope.GetRating();
         }

         scope.GetTimeSummary = function () {

             $scope.dtTimeSum = [];
             $('#cover-spin').show(0)
             $.ajax({
                 type: 'post',
                 url: 'MYMA.asmx/Get_StadiumDetails',
                 data: {
                     li_staid: $scope.SelectedStadiumId
                 },
                 dataType: 'json',
                 headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                 success: function (data, textStatus, jqXHR) {

                     $scope.dtTimeSum = data;
                     $scope.$apply();
                     $('#cover-spin').hide(0)
                 }, error: function (data, ajaxOptions, thrownError) {
                     console.log(data);
                     scope.msg = data[0].message;
                     scope.$apply();
                     scope.MsgBox();
                     $('#cover-spin').hide(0)
                 }
             });
         }


         scope.GetGallery = function () {

             $scope.dtTimeSum = [];
             $('#cover-spin').show(0)
             $.ajax({
                 type: 'post',
                 url: 'MYMA.asmx/Get_MYA_Maleabna_Stadium_Gallery',
                 data: {
                     li_staid: $scope.SelectedStadiumId
                 },
                 dataType: 'json',
                 headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                 success: function (data, textStatus, jqXHR) {
                     
                     $scope.dtGallery = data;
                     $scope.$apply();
                     $('#cover-spin').hide(0)
                 }, error: function (data, ajaxOptions, thrownError) {
                     console.log(data);
                     scope.msg = data[0].message;
                     scope.$apply();
                     scope.MsgBox();
                     $('#cover-spin').hide(0)
                 }
             });
         }



         scope.GetVideos = function () {

             $scope.dtTimeSum = [];
             $('#cover-spin').show(0)
             $.ajax({
                 type: 'post',
                 url: 'MYMA.asmx/Get_MYA_Maleabna_Stadium_Videos',
                 data: {
                     li_staid: $scope.SelectedStadiumId
                 },
                 dataType: 'json',
                 headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                 success: function (data, textStatus, jqXHR) {
                     
                     console.log(data);
                     $scope.dtVideos = data;
                     $scope.$apply();
                     $('#cover-spin').hide(0)
                 }, error: function (data, ajaxOptions, thrownError) {
                     console.log(data);
                     scope.msg = data[0].message;
                     scope.$apply();
                     scope.MsgBox();
                     $('#cover-spin').hide(0)
                 }
             });
         }



         scope.LoadReport = function () {
             
             $scope.CheckFullBlock();
             $scope.dtReport = [];
             $('#cover-spin').show(0)
             $.ajax({
                 type: 'post',
                 url: 'MYMA.asmx/Get_MYA_Maleabna_Result',
                 data: {
                     ls_stadid: $scope.SelectedStadiumId,
                     ls_date: $scope.SelDt
                 },
                 dataType: 'json',
                 headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                 success: function (data, textStatus, jqXHR) {

                     $scope.dtReport = data;
                     $scope.SelectedGovId = data[0].GovId;
                     $scope.SelectedAreaId = data[0].AreaId;


                     if (data[0].FullBlock == 'No') {
                         $scope.disFullBlock = false;
                     } else if (data[0].FullBlock == 'Yes') {
                         $scope.disFullBlock = true;
                     }


                     if ($scope.SelectedGovId !== '0') {
                         $scope.SelectedGov = data[0].GovernorateName;
                     }
                     if ($scope.SelectedAreaId !== '0') {
                         $scope.SelectedArea = data[0].AreaName;
                     }
                     if ($scope.SelectedStadiumId !== '0') {
                         $scope.SelectedStadium = data[0].StadiumName;
                     }

                     scope.GetTime();
                     $scope.$apply();
                     $('#cover-spin').hide(0)
                 }, error: function (data, ajaxOptions, thrownError) {
                     console.log(data);
                     scope.msg = data[0].message;
                     scope.$apply();
                     scope.MsgBox();
                     $('#cover-spin').hide(0)
                 }
             });
         }

         $scope.GetTimeSummary();
         $scope.LoadReport();
         $scope.GetGallery();
         $scope.GetVideos();
         //$scope.GetRating();

         scope.OnClickGovern = function (ai_govid, ai_govname) {
             $scope.SelectedGovId = ai_govid;
             $scope.SelectedGov = ai_govname;

             $scope.GetArea();
             $scope.GetStadium();
         }


         scope.OnClickArea = function (ai_Areaid, ai_Areaname) {
             $scope.SelectedAreaId = ai_Areaid;
             $scope.SelectedArea = ai_Areaname;

             $scope.GetStadium();
             //$scope.GetGovernorate();
         }

         scope.OnClickStadium = function (ai_Stadiumid, ai_Stadiumname, ai_Govid, ai_Areaid) {

             $scope.SelectedStadiumId = ai_Stadiumid;
             $scope.SelectedStadium = ai_Stadiumname;



             //$scope.SelectedGovId = ai_Govid;
             //$scope.SelectedAreaId = ai_Areaid;

             //$scope.GetArea();
             //$scope.GetGovernorate();
         }

         scope.OnClickTime = function (ai_Timeid, ai_Timename) {
             $scope.SelectedTimeId = ai_Timeid;
             $scope.SelectedTime = ai_Timename;
         }

         scope.test = function (ls_date) {

             $scope.SelDt = ls_date;

             $scope.$apply();

         }





         scope.GetTime = function () {

             $scope.dtTime = [];
             $('#cover-spin').show(0)
             $.ajax({
                 type: 'post',
                 url: 'MYMA.asmx/Get_MYA_Maleabna_TimeSlot_Search',
                 data: {
                     li_govid: $scope.SelectedGovId,
                     li_areaid: $scope.SelectedAreaId,
                     li_staid: $scope.SelectedStadiumId,
                     ld_data: $scope.SelDt
                 },
                 dataType: 'json',
                 headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                 success: function (data, textStatus, jqXHR) {

                     $scope.dtTime = data;
                     $scope.$apply();
                     $('#cover-spin').hide(0)
                 }, error: function (data, ajaxOptions, thrownError) {
                     console.log(data);
                     scope.msg = data[0].message;
                     scope.$apply();
                     scope.MsgBox();
                     $('#cover-spin').hide(0)
                 }
             });
         }


         scope.GetArea = function () {
             var as_pass;
             as_pass = '';

             if ($scope.SelectedGovId !== '0') {
                 if (as_pass == '') {
                     as_pass = ' and a.GovernorateID=' + $scope.SelectedGovId
                 } else {
                     as_pass = as_pass.substring(0, as_pass.length) + ' and a.GovernorateID=' + $scope.SelectedGovId
                 }
             }


             //if ($scope.SelectedAreaId !== 0) {
             //    if (as_pass == '') {
             //        as_pass = ' and a.AreaID=' + $scope.SelectedAreaId
             //    } else {
             //        as_pass = as_pass.substring(0, as_pass.length) + ' and a.AreaID=' + $scope.SelectedAreaId
             //    }
             //}




             $scope.dtArea = [];
             $('#cover-spin').show(0)
             $.ajax({
                 type: 'post',
                 url: 'MYMA.asmx/Get_MYA_Maleabna_Area',
                 data: {
                     ls_passvalue: as_pass,
                     ld_data: $scope.SelDt
                 },
                 dataType: 'json',
                 headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                 success: function (data, textStatus, jqXHR) {

                     $scope.dtArea = data;
                     //console.log(data[8].catname);
                     //setTimeout(function () {
                     //    $scope.$apply(function () {
                     //        $scope.message = "Timeout called!";
                     //    });
                     //}, 500);
                     //$scope.GetSubCategory();
                     //$scope.GetPartner();
                     $scope.$apply();
                     $('#cover-spin').hide(0)
                 }, error: function (data, ajaxOptions, thrownError) {
                     console.log(data);
                     scope.msg = data[0].message;
                     scope.$apply();
                     scope.MsgBox();
                     $('#cover-spin').hide(0)
                 }
             });
         }


         scope.GetGovernorate = function () {

             var as_pass;
             as_pass = '';

             //if ($scope.SelectedGovId !== 0) {
             //    if (as_pass == '') {
             //        as_pass = ' and a.GovernorateID=' + $scope.SelectedGovId
             //    } else {
             //        as_pass = as_pass.substring(0, as_pass.length) + ' and a.GovernorateID=' + $scope.SelectedGovId
             //    }
             //}


             $scope.dtGov = [];
             $('#cover-spin').show(0)
             $.ajax({
                 type: 'post',
                 url: 'MYMA.asmx/Get_MYA_Maleabna_Governorate',
                 data: {
                     ls_passvalue: as_pass,
                     ld_data: $scope.SelDt
                 },
                 dataType: 'json',
                 headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                 success: function (data, textStatus, jqXHR) {

                     $scope.dtGov = data;

                     $scope.$apply();
                     $('#cover-spin').hide(0)
                 }, error: function (data, ajaxOptions, thrownError) {
                     console.log(data);
                     scope.msg = data[0].message;
                     scope.$apply();
                     scope.MsgBox();
                     $('#cover-spin').hide(0)
                 }
             });
         }



         scope.GetStadium = function () {
             var as_pass;
             as_pass = '';

             if ($scope.SelectedGovId !== '0') {
                 if (as_pass == '') {
                     as_pass = ' and a.GovernorateID=' + $scope.SelectedGovId
                 } else {
                     as_pass = as_pass.substring(0, as_pass.length) + ' and a.GovernorateID=' + $scope.SelectedGovId
                 }
             }


             if ($scope.SelectedAreaId !== '0') {
                 if (as_pass == '') {
                     as_pass = ' and a.AreaID=' + $scope.SelectedAreaId
                 } else {
                     as_pass = as_pass.substring(0, as_pass.length) + ' and a.AreaID=' + $scope.SelectedAreaId
                 }
             }



             $scope.dtStadium = [];
             $('#cover-spin').show(0)
             $.ajax({
                 type: 'post',
                 url: 'MYMA.asmx/Get_MYA_Maleabna_Stadium',
                 data: {
                     ls_passvalue: as_pass,
                     ld_data: $scope.SelDt
                 },
                 dataType: 'json',
                 headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                 success: function (data, textStatus, jqXHR) {

                     $scope.dtStadium = data;

                     $scope.$apply();
                     $('#cover-spin').hide(0)
                 }, error: function (data, ajaxOptions, thrownError) {
                     console.log(data);
                     scope.msg = data[0].message;
                     scope.$apply();
                     scope.MsgBox();
                     $('#cover-spin').hide(0)
                 }
             });
         }




     }
   );


app.filter('trusted', ['$sce', function ($sce) {
    return function (url) {
        //console.log(url);
        //if (url === undefined) {
        //    return false;
        //}
        //var video_id = url.split('v=')[1].split('&')[0];
        return $sce.trustAsResourceUrl(url);
    };
}]);
