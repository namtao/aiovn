package com.nvn.services;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import com.nvn.entities.Account;
import com.nvn.repository.IAccountRepository;

@Service
public class AccountService implements UserDetailsService, IServices<Account, Integer> {

	@Autowired
	IAccountRepository accountRepository;

	public Account findByUserId(Integer userId) {
		return accountRepository.findByUserId(userId);
	}

	public Account findAccountByUserNamePassword(String username, String password) {
		return accountRepository.findAccountByUserNamePassword(username, password);
	}

	public Account findByName(String username) {
		return accountRepository.findAccountByUserName(username);
	}

	@Override
	public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
		Account acc = findAccountByUserName(username);
		 if (acc == null) {
	            throw new UsernameNotFoundException("User " + username + " was not found in the database");
	        }
	         
	        String roles= acc.getRole().getRoleName();
	         
	        List<GrantedAuthority> grantList= new ArrayList<GrantedAuthority>();
	        if(roles!= null)  {
//	            for(String role: roles)  {
	                // ROLE_USER, ROLE_ADMIN,..
	                GrantedAuthority authority = new SimpleGrantedAuthority("ROLE_" + roles);
	                grantList.add(authority);
//	            }
	        }        
	         
	        UserDetails userDetails = (UserDetails) new User(acc.getUsername(), //
	                acc.getPassword(),grantList);
	 
	        return userDetails;
	}

	public Account findAccountByUserName(String username) {
		return accountRepository.findAccountByUserName(username);
	}

	@Override
	public List<Account> getAll() {
		return accountRepository.findAll();
	}

	@Override
	public Optional<Account> findById(Integer id) {
		return Optional.empty();
	}

	@Override
	public void insert(Account account) {

	}

	@Override
	public void update(Account account) {

	}

	@Override
	public void delete(Account account) {

	}

	@Override
	public void deleteById(Integer id) {

	}
}
