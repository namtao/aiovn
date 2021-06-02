package com.nvn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.nvn.entities.Account;

@Repository
public interface IAccountRepository extends JpaRepository<Account, Integer> {

	@Query("select acc from Account acc where acc.userId=:userId")
	public Account findByUserId(@Param("userId") Integer userId);

	@Query("select acc from Account acc where acc.username=:username and acc.password=:password")
	public Account findAccountByUserNamePassword(@Param("username")String username, 
			@Param("password")String password);
	
	@Query("select acc from Account acc where acc.username=:username")
	public Account findAccountByUserName(@Param("username")String username);

}
