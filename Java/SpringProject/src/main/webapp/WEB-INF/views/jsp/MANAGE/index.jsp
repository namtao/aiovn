<%@page import="com.nvn.entities.Category"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<%@taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<jsp:include page="../../common/libmanage.jsp" />
<script type="text/javascript">
	var editor = ""
	$(document).ready(function() {
		editor = CKEDITOR.replace('content');

		$('#getSubject').change(function () {
			var sub = $("#getSubject option:selected").text().toLowerCase();
			$.ajax({
				type:"GET",
				url:"/manage/"+sub,
				success: function(data){
					$("#table tr").remove()
					 $.each(data, function(i, item) {
				        var tr = $('<tr>').append(
				        			$('<td>').text(item.title),
				        			$('<td>').append(
				        				$('<a>').addClass("fas fa-edit").attr("href", "https://www.w3schools.com/jquery/"),
				        				$('<a>').addClass("fas fa-trash-alt").attr("href", "https://www.w3schools.com/jquery/")
				        				)
				        		);
				        $('#table').append(tr);
				    });
				},
				
			});
		});
	});
</script>
<title>Manage</title>
<body class="skin-default-dark fixed-layout">
    <div id="main-wrapper">
        <header class="topbar">
            <nav class="navbar top-navbar navbar-expand-md navbar-dark">
                <div class="navbar-header">
                    Learn Forever
                </div>
                <div class="navbar-collapse">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item hidden-sm-up"> <a class="nav-link nav-toggler waves-effect waves-light" href="javascript:void(0)"><i class="ti-menu"></i></a></li>
                        <li class="nav-item search-box"> <a class="nav-link waves-effect waves-dark" href="javascript:void(0)"><i class="fa fa-search"></i></a>
                            <form class="app-search">
                                <input type="text" class="form-control" placeholder="Search &amp; enter"> <a class="srh-btn"><i class="fa fa-times"></i></a>
                            </form>
                        </li>
                    </ul>
                    <ul class="navbar-nav my-lg-0">
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle text-muted waves-effect waves-dark" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><img src="./resources/assets/images/users/1.jpg" alt="user" class="img-circle" width="30"></a>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>
        <aside class="left-sidebar">
            <div class="d-flex no-block nav-text-box align-items-center">
                <span>Learn Forever</span>
                <a class="waves-effect waves-dark ml-auto hidden-sm-down" href="javascript:void(0)"><i class="ti-menu"></i></a>
                <a class="nav-toggler waves-effect waves-dark ml-auto hidden-sm-up" href="javascript:void(0)"><i class="ti-menu ti-close"></i></a>
            </div>
            <div class="scroll-sidebar">
                <nav class="sidebar-nav">
                    <ul id="sidebarnav">
                        <li> <a class="waves-effect waves-dark" href="#" aria-expanded="false"><i class="fa fa-user-circle-o"></i><span class="hide-menu">Tài khoản</span></a></li>
                        <li> <a class="waves-effect waves-dark" href="#" aria-expanded="false"><i class="fas fa-file-word"></i><span class="hide-menu">Bài viết</span></a></li>
                    	<li> <a class="waves-effect waves-dark" href="logout" aria-expanded="false"><i class="fas fa-sign-out-alt"></i><span class="hide-menu">Đăng xuất</span></a></li>
                    </ul>
                </nav>
            </div>
        </aside>
        <div class="page-wrapper">
            <div class="container-fluid">
                <div class="row page-titles">
                    <div class="col-md-5 align-self-center">
                        <h4 class="text-themecolor">Quản lý hệ thống</h4>
                    </div>
                    <div class="col-md-7 align-self-center text-right">
                        <div class="d-flex justify-content-end align-items-center">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="javascript:void(0)">Trang chủ</a></li>
                                <li class="breadcrumb-item active">Quản lý hệ thống</li>
                            </ol>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4">
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex">
                                    <div>
                                        <h5 class="card-title">Danh sách bài viết</h5>
                                    </div>
                                    <div class="ml-auto">
                                        <select class="custom-select b-0" name="getSubject" id="getSubject">
                                            <c:forEach var="index" items="${allSubject}">
                                                    <option value="${index.subjectId}">${index.subjectName}</option>
                                            </c:forEach>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <table class="table table-hover" id="table">
                                    <tbody>
                                        <c:forEach var="index" items="${allLesson}">
                                            <tr>
                                                <td>${index.title}</td>
                                                <th scope="row">
                                                    <a class="fas fa-edit" href="update/${index.id.subjectId}/${index.id.url}"></a> 
                                                    <a class="fas fa-trash-alt" href="delete/${index.id.subjectId}/${index.id.url}"></a>
                                                </th>
                                            </tr>
                                        </c:forEach>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                    </div>
                    <div class="col-lg-8">
                        <div class="card oh">
                            <div class="card-body">
                                <form:form action="insert" id="form" modelAttribute="lesson" method="POST" class="form-horizontal form-material">
                                    <div class="form-group">
                                        <label class="col-md-12">Tiêu đề</label>
                                        <div class="col-md-12">
                                            <input type="text" class="form-control form-control-line" 
                                            name="title" id="title">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="example-email" class="col-md-12">Hình ảnh</label>
                                        <div class="col-md-12">
                                            <input type="text" class="form-control form-control-line" 
                                            name="image" id="image">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-12">Thể loại</label>
                                        <div class="col-md-12">
                                            <select id="sub" name="id.subjectId" class="form-control form-control-line">
                                                <c:forEach var="index" items="${allCategory}">
                                                    <option value="${index.categoryId}">${index.categoryName}</option>
                                                </c:forEach>
                                            </select>
                                        </div>
                                    </div>
                                    <!-- <div class="form-group">
                                        <label class="col-md-12">UserID</label>
                                        <div class="col-md-12">
                                            <input type="text" class="form-control form-control-line"
                                            name="account.userId" id="user">
                                        </div>
                                    </div> -->
                                    <div class="form-group">
                                        <label class="col-md-12">Url</label>
                                        <div class="col-md-12">
                                            <input type="text"  class="form-control form-control-line"name="id.url"
                                            id="url">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-12">Tóm tắt nội dung</label>
                                        <div class="col-md-12">
                                            <input type="text"  class="form-control form-control-line"name="shortContent"
                                            id="shortContent">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-12">Nội dung</label>
                                        <div class="col-md-12">
                                            <textarea rows="5" class="form-control form-control-line" name="content" id="content"></textarea>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-12">
                                            <button class="btn btn-success" id="update">Cập nhật danh sách</button>
                                        </div>
                                    </div>
                                </form:form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <footer class="footer">
            © 2020 Nguyễn Văn Nam
        </footer>
    </div>
</body>

<script type="text/javascript">
	$("#add").click(function() {
		$("#form").submit();
	});
</script>

</html>