package com.nvn.controller;

import java.util.List;

import javax.servlet.http.HttpServletRequest;

import com.nvn.services.AccountService;
import com.nvn.services.CategoryService;
import com.nvn.services.LessonService;
import com.nvn.services.SubjectService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.client.RestTemplate;

import com.nvn.entities.Category;
import com.nvn.entities.Lesson;

@Controller
public class ManageController {
	@Qualifier("lessonService")
	@Autowired
	LessonService lessonService;

	@Autowired
	CategoryService categoryService;

	@Autowired
	SubjectService subjectService;

	@Autowired
	AccountService accountService;

	@Autowired
	RestTemplate restTemplate;

	@GetMapping(value = "/manage")
	public String viewManage(Model model, @ModelAttribute("lesson") Lesson lesson, HttpServletRequest request) {
		
		// final String uri = "http://localhost:8080/lesson/html";

		// Lesson result = restTemplate.getForObject(uri, Lesson.class);

		// System.out.println(result);

		if (request.isUserInRole("ROLE_ADMIN")) {
			model.addAttribute("allLesson", lessonService.getAll("c"));
			model.addAttribute("allCategory", categoryService.getAll());
			model.addAttribute("allSubject", subjectService.getAll());
			return "MANAGE/index";
		}
		return "redirect:/c";
	}

	@RequestMapping(value = "/lesson/html", method = RequestMethod.GET)
	public ResponseEntity<Lesson> listAllUsers() {
		Lesson lesson = lessonService.getAll().get(0);
    	return new ResponseEntity<Lesson>(lesson, HttpStatus.OK);
	}

	@GetMapping(value = "/manage/{sub}", produces = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public List<Lesson> view(Model model, @PathVariable String sub) {
		return lessonService.getAll(sub);
	}

	@PostMapping(value = "/insert")
	public String insert(Model model, @ModelAttribute("lesson") Lesson lesson) {
		UserDetails userDetails = (UserDetails) SecurityContextHolder.getContext().getAuthentication().getPrincipal();
		lessonService.insert(lesson);
		model.addAttribute("allLesson", lessonService.getAll());
		model.addAttribute("allLesson", lessonService.getAll("java"));
		model.addAttribute("allCategory", categoryService.getAll());
		model.addAttribute("allSubject", subjectService.getAll());
		return "redirect:/manage";
	}

	@GetMapping(value = "/update/{subjectId}/{url}")
	public String update(Model model, @ModelAttribute("lesson") Lesson lesson, @PathVariable int subjectId,
			@PathVariable String url) {
		Lesson les = lessonService.findById(subjectId, url);
		model.addAttribute("lesson", les);
		return "MANAGE/update";
	}

	@GetMapping(value = "/update/{subjectId}/{url}/fn")
	public String fnupdate(Model model, @ModelAttribute("lesson") Lesson lesson, @PathVariable int subjectId,
			@PathVariable String url) {
		Lesson les = lessonService.findById(subjectId, url);
		model.addAttribute("lesson", les);
		lessonService.update(lesson);
		model.addAttribute("allLesson", lessonService.getAll());
		return "MANAGE/manage";
	}

	@GetMapping(value = "/delete/{subjectId}/{url}")
	public String delete(Model model, @PathVariable int subjectId, @PathVariable String url) {
		lessonService.delete(subjectId, url);
		model.addAttribute("allLesson", lessonService.getAll());
		return "MANAGE/manage";
	}

	@GetMapping(value = "/insertCategory")
	public String insertCategory(Model model, @ModelAttribute("category") Category category) {
		categoryService.insert(category);
		model.addAttribute("allLesson", lessonService.getAll());
		model.addAttribute("allCategory", categoryService.getAll());
		return "MANAGE/manage";
	}

	@GetMapping("/close")
	public String close(Model model) {
		return "redirect:/java";
	}
}
