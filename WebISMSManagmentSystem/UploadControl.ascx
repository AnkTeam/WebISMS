﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadControl.ascx.cs" Inherits="WebISMSManagmentSystem.UploadControl" %>
<link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.js"></script>

    <script src="Scripts/bootstrap.min.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.13/js/bootstrap-multiselect.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.13/css/bootstrap-multiselect.css" />

  <button type="button" id="btnAdd" class="btn btn-info btn-lg" data-toggle="modal" data-target="#uploadTemplateModel">

        Upload Template
        
    </button>
    <div class=" modal fade" id="uploadTemplateModel" role="dialog" data-keyboard="false" data-backdrop="false">

        <div class="modal-dialog">
            <div class="modal-content">
                <div class=" modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class=" modal-title">
                        Upload Template
                    </h4>

                </div>

                <div class="modal-body">
                    <div class="row">

                        <div class="col-sm-4">
                            <div>Select Department: </div>
                        </div>
                        <div class="col-sm-4">
                            <select id="Dept" name="Dept" multiple="multiple" style="float: left">
                                <% foreach (var dept in depts)
                                   { %>
                                <option value="<%=dept.Id %>"><%= dept.Name %></option>

                                <%} %>
                            </select>
                        </div>



                    </div>

                    <% if (Role == UserRole.IsoUser)
                       { %>
                    <div class="input-group">
                        <label class="input-group-btn">
                            <span class="btn btn-primary">Browse…<input type="file" name="fileTemplate" id="fileTemplate" value="" style="display: none;" multiple="multiple" onchange="ValidateSingleInput(this); " />
                            </span>
                        </label>
                        <input type="text" id ="fileInput" class="form-control" readonly="">
                    </div>


                    <%} %>
                    <%else
                       { %>
                    <div class="input-group">
                        <label class="input-group-btn">
                            <span class="btn btn-primary">Browse…<input type="file" name="fileTemplate" id="fileTemplate" style="display: none;" value="" onchange="ValidateSingleInput(this);" />
                            </span>
                        </label>
                        <input type="text" id ="fileInput" class="form-control" readonly="">
                    </div>


                    <%} %>

                    <br />
                    <div class="col-xs-12 col-sm-12 progress-container">
                        <div class="progress progress-striped active" style=" width:100%;"  aria-valuenow="100" aria-valuemin="100" aria-valuemax="100" >
                            <div class="progress-bar progress-bar-success" style=" width:100%;"  aria-valuenow="100" aria-valuemin="100" aria-valuemax="100"  ></div>
                        </div>
                    </div>
                    <br />
                    <input type="button" name="btnUploadTemplate" id="btnUploadTemplate" value="Upload Template" class="btn-primary"  style ="float:right;" />

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                </div>

            </div>
        </div>
    </div>




    <style type="text/css">
        .modal-dialog {
            margin-right: 500px;
            margin-top: 50px;
            position: static !important;
        }

       .input-group .form-control {
            width: 100%;
            margin-bottom: 5px;
            margin-left: 0px;
        }
    </style>


    <script type="text/javascript">
        $(document).ready(function () {
            $('.progress').hide();

            $("#Dept").multiselect({ includeSelectAllOption: true, nonSelectedText: 'Select Department' });
            $("#btnUploadTemplate").click(function () {
                var dept = ValidateDept();
                if (dept.trim().length > 0) {
                    UploadTemplate();
                }
                else {
                    alert('Please select department');
                }
            });
            $("#btnAdd").click(function () {
                RefreshUploadTemplate();
            });

        });
        function UploadTemplate() {
            var files = $("#fileTemplate")[0].files;
            //   var progressbar = $(".progress-bar");
            if (files.length > 0) {
                var formData = new FormData();
                for (var i = 0; i < files.length; i++) {
                    formData.append(files[i].name, files[i]);
                }
                formData.append("Department", ValidateDept());


                $(".progress-bar").animate({
                    width: "100%"
                }, 0);
                $(".progress").show();
                $.ajax({

                    url: "/Upload.ashx",
                    method: "post",
                    data: formData,
                    contentType: false,
                    processData: false,
                    success: function (data) {
                        alert('File uploaded successfully.');
                        RefreshUploadTemplate();
                    },
                    error: function (error) {
                        alert('Error while uploading file');
                        RefreshUploadTemplate();
                    }

                });

            }
            else {
                alert('Please select file .doc,.xls,.xlsx,.ppt,.pptx extension based');
            }


        }

        function ValidateDept() {
            var department = $("#Dept option:selected");
            var selectedDept = "";
            department.each(function () {
                selectedDept += $(this).val() + ',';
            });
            return selectedDept;
        }

        var _validFileExtensions = [".doc", ".xls", ".xlsx", ".ppt", ".pptx"];
        function ValidateSingleInput(oInput) {
            if (oInput.type == "file") {
                var files = oInput.files;
                for (var i = 0; i < oInput.files.length; i++) {
                    if (oInput.files.length > 1) {
                        $("#fileInput").val(oInput.files.length + " files selected");
                    }
                    else {
                        $("#fileInput").val(files[i].name);
                    }
                    var sFileName = files[i].name; //oInput.value;
                    var fileSize = parseFloat((((files[i].size) / 1024) / 1024)).toFixed(2);
                    if (sFileName.length > 0) {
                        var blnValid = false;
                        for (var j = 0; j < _validFileExtensions.length; j++) {
                            var sCurExtension = _validFileExtensions[j];
                            if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) {
                                blnValid = true;
                                break;
                            }
                        }

                        if (!blnValid) {
                            alert("Sorry, " + sFileName + " is invalid, allowed extensions are: " + _validFileExtensions.join(", "));
                            oInput.value = "";
                            $("#fileInput").val("");
                            return false;
                        }
                    }
                    if (fileSize > 25) {
                        alert('file :' + sFileName + ' and size :' + fileSize + ' is exceed , you can upload only 25 mb');
                        oInput.value = "";
                        $("#fileInput").val("");
                        return false
                    }
                }
            }

            return true;
        }

        function RefreshUploadTemplate() {
            $('.progress').hide();
            $('.progress-bar').css('width', '0%').attr('aria-valuenow', 0);
            $("#Dept").multiselect("deselectAll", false).multiselect("refresh");
            $("#Dept").multiselect({ nonSelectedText: 'Select Department' });
            $("#fileTemplate").val("");
            $("#fileInput").val("");
        }



    </script>