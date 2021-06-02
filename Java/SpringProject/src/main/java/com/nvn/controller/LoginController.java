package com.nvn.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.nvn.services.AccountService;
import org.springframework.beans.factory.ObjectFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.web.authentication.logout.SecurityContextLogoutHandler;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class LoginController {

	@Autowired
	AccountService accountService;

	@Autowired
	ObjectFactory<HttpSession> httpSessionFactory;

	@GetMapping(value = "/login")
	public String login() {
		return "Login/login";
	}

	@GetMapping(value = "/logout")
	public String logout(HttpServletRequest request, HttpServletResponse response) {
		Authentication auth = SecurityContextHolder.getContext().getAuthentication();
		if (auth != null) {
			new SecurityContextLogoutHandler().logout(request, response, auth);
		}
		return "redirect:/login";
	}

	/*
	 * @RequestMapping(value = "/checkLogin") public String checkLogin(Model
	 * model, @ModelAttribute("account") Account account) { Account acc =
	 * accountService.findAccountByUserNamePassword(account.getUsername(),
	 * account.getPassword()); if(acc!=null) { HttpSession session =
	 * httpSessionFactory.getObject(); session.setAttribute("currentAccount", acc);
	 * 
	 * // Account acc1= (Account) session.getAttribute("currentAccount"); return
	 * "redirect:/manage"; } return "redirect:/login"; }
	 */
}
