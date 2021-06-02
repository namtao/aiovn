<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<%@taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

<html>
<head>
<title>Manage</title>
<jsp:include page="../../common/lib.jsp" />
<link rel="stylesheet" href="./resources/css/styleManage.css">
</head>
<script type="text/javascript">
	var editor = ""
	$(document).ready(function() {
		editor = CKEDITOR.replace('content');
	});
</script>
<div class="container-fluid">
	<div class="row">
		<div class="col-12">
			<form:form action="update/${lesson.id.subjectId}/${lesson.id.url}/fn" id="modal" modelAttribute="lesson" method="POST">
						<div>
							<label for="title">Tiêu đề</label> <form:input type="text" path="title"
								name="title" id="title"/>
						</div>

						<div>
							<label for="image">Hình ảnh</label> <form:input type="text" path="image"
								name="image" id="image"/>
						</div>

						<div>
							<label for="sub">Thể loại</label> <form:input type="text" path="id.subjectId"
								id="sub"/>
						</div>

						<div>
							<label for="user">UserId</label> <form:input type="text" path="account.userId"
								id="user"/>
						</div>

						<div>
							<label for="url">Url</label> <form:input type="text" path="id.url"
								id="url"/>
						</div>
						
						<div>
							<label for="shortContent">Nội dung ngắn</label> <form:input type="text" path="shortContent"
								id="shortContent"/>
						</div>

						<label for="content">Nội dung</label>
						<form:textarea path="content" id="content"/>
						<br />
						
						<input type="submit" class="btn btn-primary" id="update" value="Cập nhật"/>
					</form:form>
		</div>
	</div>
</div>