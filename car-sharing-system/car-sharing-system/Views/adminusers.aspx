﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="adminusers.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.adminusers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

 <!-- /.row -->
            <div class="row">


               <div class="col-lg-3 col-md-6">
                    <div class="panel panel-red">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"></div>
                                    <br>
                                    <div>Users!</div>
                                </div>
                            </div>
                        </div>
                        <a href="adminusers.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View users</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-car fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"></div>
                                    <br>
                                    <div>Car history!</div>
                                </div>
                            </div>
                        </div>
                        <a href="admincar.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View cars</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-bar-chart-o fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <br>
                                    <div>View Issues!</div>
                                </div>
                            </div>
                        </div>
                        <a href="adminissue.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View issues</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>


            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-8">
                    <div class="panel panel-default">
                        
                        <div class="panel-heading">
   
                            <div class="pull-right">
                                
                                <div class="btn-group">
                                    


                                </div>
                               
                            </div>
                            
                        </div>


                        <!-- /.panel-heading -->
                      

                        <div class="panel-body">

                        <div  id="pagers" runat="server"> 


                        </div>

                        <div class="table" id="Usertable" runat="server">
                            <div class="userrowHead">
                                <div class="cellHead firstCol">
                                    <h4>User's ID</h4>
                                </div>
                                <div class="cellHead col">
                                    <h4>User's Name</h4>
                                </div>
                                <div class="cellHead col lic">
                                    <h4>User's license</h4>
                                </div>
                                <div class="cellHead col em">
                                    <h4>User's Email</h4>
                                </div>
                                <div class="cellHead col">
                                    <h4>View User's Profile</h4>
                                </div>
                                <div class="cellHead col">
                                    <h4>View User's Booking History</h4>
                                </div>
                            </div>    
                        </div>
                


                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                    <!-- /.panel-heading -->
                    <!-- /.table-responsive -->
                </div>
                <!-- /.col-lg-4 (nested) -->
                <div class="col-lg-8">
                    
                <!-- /.col-lg-8 (nested) -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.panel-body -->
   

</asp:Content>