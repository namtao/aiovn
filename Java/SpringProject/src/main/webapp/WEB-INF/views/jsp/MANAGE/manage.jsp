<%@page import="com.nvn.entities.Category"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<%@taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<!DOCTYPE html>
<title>Quản trị hệ thống</title>
<jsp:include page="../../common/lib.jsp" />
<link rel="stylesheet" href="./resources/css/styleManage.css">
<script type="text/javascript">
	var editor = ""
	$(document).ready(function() {
		editor = CKEDITOR.replace('content');
	});
</script>
<body>
	<div class="container-fluid">
		<div class="row">
			<div class="col-3">
				<div class="list-group" id="list-tab" role="tablist">
					<a class="list-group-item list-group-item-action active"
						id="list-lesson-list" data-toggle="list" href="#list-lesson"
						role="tab" aria-controls="lesson">Bài viết</a> <a
						class="list-group-item list-group-item-action"
						id="list-category-list" data-toggle="list" href="#list-category"
						role="tab" aria-controls="category">Thể loại</a> <!-- <a
						class="list-group-item list-group-item-action"
						id="list-account-list" data-toggle="list" href="#list-account"
						role="tab" aria-controls="account">Tài khoản</a> <a
						class="list-group-item list-group-item-action"
						id="list-members-list" data-toggle="list" href="#list-members"
						role="tab" aria-controls="members">Hình ảnh</a> <a
						class="list-group-item list-group-item-action"
						id="list-image-list" data-toggle="list" href="#list-image"
						role="tab" aria-controls="image">Thành viên</a> -->
						<a class="list-group-item list-group-item-action"
						id="exit" href="close">Thoát</a>
				</div>
			</div>
			<div class="col-9">
				<div class="tab-content" id="nav-tabContent">
					<!-- Tab 1 -->
					<div class="tab-pane fade show active" id="list-lesson"
						role="dialog" aria-labelledby="list-lesson-list">

						<table class="table table-hover">
							<thead>
								<tr>
									<th scope="col">Tên bài</th>
									<th scope="col">Tên môn</th>
									<th scope="col">Thể loại</th>
									<th scope="col"></th>
								</tr>
							</thead>
							<tbody>
								<c:forEach var="index" items="${allLesson}">
									<tr>
										<td>${index.title}</td>
										<td>${index.subject.subjectName}</td>
										<td>${index.subject.category.categoryName}</td>
										<th scope="row">
											<a class="fas fa-edit" href="update/${index.id.subjectId}/${index.id.url}"></a> 
											<a class="fas fa-trash-alt" href="delete/${index.id.subjectId}/${index.id.url}"></a>
										</th>
									</tr>
								</c:forEach>
							</tbody>
						</table>


						<!-- Button trigger modal -->
						<button type="button" class="btn btn-primary" data-toggle="modal"
							data-target="#exampleModalScrollable">Thêm</button>

					</div>

					<!-- Tab 2 -->
					<div class="tab-pane fade" id="list-category" role="tabpanel"
						aria-labelledby="list-category-list">

						<table class="table table-hover">
							<thead>
								<tr>
									<th scope="col">Thể loại</th>
								</tr>
							</thead>
							<tbody>
								<tr>
									<c:forEach var="index" items="${allCategory}">
									<tr>
										<td>${index.categoryName}</td>
									</tr>
								</c:forEach>
								</tr>
							</tbody>
						</table>


						<!-- Button trigger modal -->
						<button type="button" class="btn btn-primary" data-toggle="modal"
							data-target="#exampleModalScrollable2">Thêm</button>

					</div>

				<input type="hidden" name="nam" value="nam" />
			</div>
		</div>
	</div>
	</div>
	<!-- Modal -->
	<div class="modal fade bd-example-modal-lg" id="exampleModalScrollable"
		data-backdrop="static" tabindex="-1" role="dialog"
		aria-labelledby="staticBackdropLabel" aria-hidden="true">
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title" id="staticBackdropLabel">Bài viết</h5>
					<button type="button" class="close" data-dismiss="modal"
						aria-label="Close">
						<span aria-hidden="true">&times;</span>
					</button>
				</div>
				<div class="modal-body">
					<form:form action="insert" id="modal" modelAttribute="lesson" method="POST">
						<div>
							<label for="title">Tiêu đề</label> <input type="text"
								name="title" id="title"/>
						</div>

						<div>
							<label for="image">Hình ảnh</label> <input type="text"
								name="image" id="image">
						</div>

						<div>
							<label for="sub">Thể loại</label> <input type="text" name="id.subjectId"
								id="sub">
						</div>
						
						<div>
							<label for="abc">Dropbox</label> 
							<select id="abc" name="country">
								<c:forEach var="index" items="${allCategory}">
									<option value="index">${index.categoryName}</option>
								</c:forEach>
							</select>
						</div>

						<div>
							<label for="user">UserId</label> <input type="text" name="account.userId"
								id="user">
						</div>

						<div>
							<label for="url">Url</label> <input type="text" name="id.url"
								id="url">
						</div>
						
						<div>
							<label for="shortContent">Nội dung ngắn</label> <input type="text" name="shortContent"
								id="shortContent">
						</div>

						<label for="content">Nội dung</label>
						<textarea name="content" id="content"></textarea>
						<br />
					</form:form>
				</div>
				<div class="modal-footer">
					<button type="button" class="btn btn-secondary"
						data-dismiss="modal">Đóng</button>
					<button type="button" class="btn btn-primary" id="add">Thêm</button>
				</div>
			</div>
		</div>
	</div>
	
	<!-- Modal thể loại -->
	<div class="modal fade bd-example-modal-lg" id="exampleModalScrollable2"
	data-backdrop="static" tabindex="-1" role="dialog"
	aria-labelledby="staticBackdropLabel" aria-hidden="true">
	<div class="modal-dialog modal-lg" role="document">
		<div class="modal-content">
			<div class="modal-header">
				<h5 class="modal-title" id="staticBackdropLabel">Thể loại</h5>
				<button type="button" class="close" data-dismiss="modal"
					aria-label="Close">
					<span aria-hidden="true">&times;</span>
				</button>
			</div>
			<div class="modal-body">
				<form:form action="insertCategory" id="modalCategory" modelAttribute="category" method="POST">
					<div>
						<label for="title">Tên thể loại</label> <input type="text"
							name="categoryName" id="title"/>
					</div>
				</form:form>
			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-secondary"
					data-dismiss="modal">Đóng</button>
				<button type="button" class="btn btn-primary" id="addCategory">Thêm</button>
			</div>
		</div>
	</div>
</div>

</body>

<script type="text/javascript">
	$("#add").click(function() {
		$("#modal").submit();
	});
	
	$("#addCategory").click(function() {
		$("#modalCategory").submit();
	});
</script>
