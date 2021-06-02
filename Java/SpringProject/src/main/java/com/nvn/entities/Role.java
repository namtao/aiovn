package com.nvn.entities;

import static javax.persistence.GenerationType.IDENTITY;

import java.util.HashSet;
import java.util.Set;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;

@Entity
@Table(name = "ROLE")
public class Role implements java.io.Serializable {

	private static final long serialVersionUID = 1L;
	private Integer roleId;
	private String roleName;
	private Set<Account> account = new HashSet<Account>(0);

	public Role() {
	}

	public Role(String roleName) {
		this.roleName = roleName;
	}

	public Role(String roleName, Set<Account> account) {
		this.roleName = roleName;
		this.account = account;
	}

	@Id
	@GeneratedValue(strategy = IDENTITY)

	@Column(name = "RoleId", unique = true, nullable = false)
	public Integer getRoleId() {
		return this.roleId;
	}

	public void setRoleId(Integer roleId) {
		this.roleId = roleId;
	}

	@Column(name = "RoleName", nullable = false, length = 45)
	public String getRoleName() {
		return this.roleName;
	}

	public void setRoleName(String roleName) {
		this.roleName = roleName;
	}

	@OneToMany(fetch = FetchType.LAZY, mappedBy = "role")
	public Set<Account> getAccount() {
		return this.account;
	}

	public void setAccount(Set<Account> account) {
		this.account = account;
	}

}
