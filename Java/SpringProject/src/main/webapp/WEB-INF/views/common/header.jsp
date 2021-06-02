<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<jsp:include page="../common/lib.jsp" />
<section>
	<div>
		<nav
			class="navbar navbar-expand-lg navbar-dark bg-success fixed-top header">
			<a class="navbar-brand" href="#">Learn Forever</a>
			<button class="navbar-toggler" type="button" data-toggle="collapse"
				data-target="#navbarSupportedContent"
				aria-controls="navbarSupportedContent" aria-expanded="false"
				aria-label="Toggle navigation">
				<span class="navbar-toggler-icon"></span>
			</button>

			<div class="collapse navbar-collapse" id="navbarSupportedContent">
				<ul class="navbar-nav ml-auto justify-content-center item-menu">
					<li class="nav-item" id="c"><a class="nav-link" 
					href="c">C/C++</a></li>
					<li class="nav-item" id="html"><a class="nav-link" 
					href="html">HTML</a></li>
					<li class="nav-item" id="css"><a class="nav-link" 
					href="css">CSS</a></li>
					<li class="nav-item" id="javascript"><a class="nav-link"
						href="javascript">JavaScript</a></li>
					<li class="nav-item" id="java"><a class="nav-link" 
					href="java">Java</a></li>
					<li class="nav-item" id="python"><a class="nav-link"
						href="python">Python</a></li>
				</ul>
				<form class="form-inline my-2 my-lg-0">
					<input class="form-control mr-sm-2" type="search"
						placeholder="Tìm kiếm" aria-label="Search">
				</form>
				<!-- <a href="login" class="login">Đăng nhập</a> -->
				<a href="logout" class="login" id="logout" title="Đăng xuất">${currentUser}</a>
			</div>
		</nav>
	</div>
</section>