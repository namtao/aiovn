package com.nvn.configuration;

import org.apache.catalina.filters.RemoteIpFilter;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.HttpMethod;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.web.client.RestTemplate;

import com.nvn.services.AccountService;

@Configuration
@EnableWebSecurity
public class WebSecurityConfiguration extends WebSecurityConfigurerAdapter {

	@Autowired
    private AccountService userDetailsService;
	
	
	@Bean
	public BCryptPasswordEncoder passwordEncoder() {
		return new BCryptPasswordEncoder();
	};
	

	@Bean
	public RestTemplate getRestTemplate() {
		return new RestTemplate();
	}
	
	@Override
	protected void configure(HttpSecurity http) throws Exception {
		http
			.csrf().disable()
			.authorizeRequests()
				.antMatchers("/", "/home","/api/**").permitAll()
				.antMatchers(HttpMethod.POST,"/api/**").permitAll()
				.antMatchers("/resources/**").permitAll()
				.antMatchers("/lesson/**").permitAll()
				.antMatchers("/manage").hasRole("ADMIN")
				.anyRequest().authenticated()
				.and()
			.formLogin()
				.loginPage("/login")
				.usernameParameter("username")
			    .passwordParameter("password")
				.permitAll()
				.defaultSuccessUrl("/")
			    .failureUrl("/login?error")
				.and()
			.logout()
				.logoutUrl("/logout")
				.permitAll();
	}
	
	@Override
	protected void configure(AuthenticationManagerBuilder auth) throws Exception {
		 auth
         .userDetailsService(userDetailsService)
         .passwordEncoder(passwordEncoder());
	}

	@Bean
	public RemoteIpFilter remoteIpFilter() {
		return new RemoteIpFilter();
	}
}
