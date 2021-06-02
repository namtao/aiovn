package com.nvn.controller;

import javax.servlet.http.HttpSession;

import com.nvn.services.AccountService;
import com.nvn.services.CategoryService;
import com.nvn.services.LessonService;
import org.springframework.beans.factory.ObjectFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;

import com.nvn.entities.Lesson;
import com.nvn.util.Util;

@Controller
public class LessonController {

	@Qualifier("lessonService")
	@Autowired
	LessonService lessonService;

	@Autowired
	AccountService accountService;

	@Autowired
	CategoryService categoryService;

	@Autowired
	ObjectFactory<HttpSession> httpSessionFactory;

	@GetMapping("/{subject}")
	public String getLesson(@PathVariable String subject, Model model) {
		HttpSession session = httpSessionFactory.getObject();
		UserDetails userDetails = (UserDetails) SecurityContextHolder.getContext().getAuthentication().getPrincipal();
		session.setAttribute("currentUser", accountService.findAccountByUserName(userDetails.getUsername()).getFullName());
		model.addAttribute("listLesson", lessonService.getAll(subject));
		model.addAttribute("listCategory", categoryService.getAll());
		model.addAttribute("url", Util.getUrl());
		return "Subject/listsubject";
	}

	@GetMapping("/{subject}/{url}")
	public String viewLessonByUrl(@PathVariable String subject, @PathVariable String url, Model model) {
		Lesson lesson = lessonService.findByName(subject, url);
		model.addAttribute("lesson", lesson);
		model.addAttribute("listLesson", lessonService.getAll(subject));
		model.addAttribute("url", Util.getUrl());
		return "Subject/subjectdetail";
	}

}