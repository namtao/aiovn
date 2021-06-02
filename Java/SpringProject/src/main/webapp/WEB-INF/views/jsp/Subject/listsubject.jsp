<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<%@ taglib uri = "http://java.sun.com/jsp/jstl/functions" prefix = "fn" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<c:set var = "urlUpperCase" value = "${fn:toUpperCase(url)}" />
<title>${urlUpperCase}</title>
<jsp:include page="../../common/lib.jsp" />
<jsp:include page="../../common/header.jsp" />
<link rel="stylesheet" href="./resources/css/styleHTML.css">

<script>
	$('#${url}').addClass('active');
</script>
</head>

<div class="container main">
	<div class="row">
		<div class="col-9">
			<div class="container-fluid">
				<c:if test="${not empty listLesson}">
					<c:forEach var="index" items="${listLesson}">
						<div class="row rows">
							<div class="col-3">
								<div class="imagehover column">
									<figure> <img src="${index.image}" class="img"></figure>
								</div>
							</div>
							<div class="col-9">
								<%-- <a href="${url}/${index.url}" class="title">${index.title}</a> <!-- jdbc --> --%>
								<a href="${url}/${index.id.url}" class="title">${index.title}</a> <!-- hibernate -->
								<div class="shortcontent">${index.shortContent}</div>
								<%-- <div class="personpost">Đăng bởi: ${index.fullName}</div> <!-- jdbc --> --%>
								<div class="personpost">Đăng bởi: ${index.account.fullName}</div> <!-- hibernate -->
							</div>
						</div>
					</c:forEach>
				</c:if>
			</div>
		</div>

		<div class="col-3">
			<div class="fb-page"
				data-href="https://www.facebook.com/VienCongNgheDevmaster25"
				data-tabs="" data-width="" data-height="" data-small-header="true"
				data-adapt-container-width="true" data-hide-cover="false"
				data-show-facepile="true">
				<blockquote cite="https://www.facebook.com/VienCongNgheDevmaster25"
					class="fb-xfbml-parse-ignore">
					<a href="https://www.facebook.com/VienCongNgheDevmaster25">Viện
						Công Nghệ Và Đào Tạo Devmaster</a>
				</blockquote>
			</div>
			<%-- <div class="category">THỂ LOẠI</div>
			<c:forEach var="index" items="${listCategory}">
				<a href="#" class="info">${index.categoryName}</a>
				<br />
			</c:forEach> --%>

			<%-- 			<a data-toggle="collapse" href="#collapseExample"
				aria-controls="collapseExample" class="collap dropdown-toggle">THỂ
				LOẠI</a>
			<div class="collapse" id="collapseExample">
				<c:forEach var="index" items="${listCategory}">
					<a href="#" class="info">${index.categoryName}</a>
					<br />
				</c:forEach>
			</div>
			<br /> --%>

			<div id="accordionExample">
				<div>
					<div id="headingOne">
						<div class="collap" data-toggle="collapse"
							data-target="#collapseOne" aria-expanded="true"
							aria-controls="collapseOne">Bài viết mới</div>
					</div>

					<div id="collapseOne" class="collapse show"
						aria-labelledby="headingOne" data-parent="#accordionExample">
						<div>
							<c:forEach var="index" items="${listCategory}">
								<a href="#" class="info">${index.categoryName}</a>
								<br />
							</c:forEach>
						</div>
					</div>
				</div>
				<div>
					<div id="headingTwo">
						<div class="collap" data-toggle="collapse"
							data-target="#collapseTwo" aria-expanded="false"
							aria-controls="collapseTwo">Thể loại</div>
					</div>
					<div id="collapseTwo" class="collapse" aria-labelledby="headingTwo"
						data-parent="#accordionExample">
						<div>
							<c:forEach var="index" items="${listCategory}">
								<a href="#" class="info">${index.categoryName}</a>
								<br />
							</c:forEach>
						</div>
					</div>
				</div>
				<div>
					<div id="headingThree">
						<div class="collap" data-toggle="collapse"
							data-target="#collapseThree" aria-expanded="false"
							aria-controls="collapseThree">Đóng góp</div>
					</div>
					<div id="collapseThree" class="collapse"
						aria-labelledby="headingThree" data-parent="#accordionExample">
						<div>
							<c:forEach var="index" items="${listCategory}">
								<a href="#" class="info">${index.categoryName}</a>
								<br />
							</c:forEach>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>

<jsp:include page="../../common/footer.jsp" />