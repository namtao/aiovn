<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>${lesson.title}</title>
<jsp:include page="../../common/lib.jsp" />
<jsp:include page="../../common/header.jsp" />
<link rel="stylesheet" href="./resources/css/styleHTML.css">

<script>
	$('#${url}').addClass('active');
</script>
</head>
<div class="container main">
	<div class="row">
		<div class="col-9 rows">
			<div class="container-fluid">
				${lesson.content}
			</div>
		</div>

		<div class="col-3">
			<div class="fb-page" data-href="https://www.facebook.com/VienCongNgheDevmaster25" data-tabs="" data-width="" data-height="" data-small-header="true" data-adapt-container-width="true" data-hide-cover="false" data-show-facepile="true"><blockquote cite="https://www.facebook.com/VienCongNgheDevmaster25" class="fb-xfbml-parse-ignore"><a href="https://www.facebook.com/VienCongNgheDevmaster25">Viện Công Nghệ Và Đào Tạo Devmaster</a></blockquote></div>
			<div class="category">Bài học</div>
			<c:forEach var="index" items="${listLesson}">
				<a href="${url}/${index.id.url}" class="info">${index.title}</a>
				<br />
			</c:forEach>
		</div>
	</div>
</div>