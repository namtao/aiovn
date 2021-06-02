package com.nvn.entities;

import java.util.Date;
import java.util.HashSet;
import java.util.Set;
import javax.persistence.*;
import org.hibernate.annotations.GenericGenerator;
import org.hibernate.annotations.Parameter;

@Entity
@Table(name = "ACCOUNT")
public class Account implements java.io.Serializable {

	private static final long serialVersionUID = 1L;
	
	private Integer userId;
	private Role role;
	private String username;
	private String password;
	private Date timeCreate;
	private String fullName;
	private Date dateOfBirth;
	private String email;
	private String phone;
	private Set<Subject> subjects = new HashSet<Subject>(0);

	public Account() {
	}

	public Account(Role role, String username, String password, String fullName, Date dateOfBirth, String email,
			String phone, int roleId) {
		this.role = role;
		this.username = username;
		this.password = password;
		this.fullName = fullName;
		this.dateOfBirth = dateOfBirth;
		this.email = email;
		this.phone = phone;
	}

	public Account(Role role, String username, String password, Date timeCreate, String fullName, Date dateOfBirth,
			String email, String phone, int roleId, Set<Lesson> lessons, Set<Subject> subjects) {
		this.role = role;
		this.username = username;
		this.password = password;
		this.timeCreate = timeCreate;
		this.fullName = fullName;
		this.dateOfBirth = dateOfBirth;
		this.email = email;
		this.phone = phone;
		this.subjects = subjects;
	}

	@GenericGenerator(name = "generator", strategy = "foreign", parameters = @Parameter(name = "property", value = "role"))
	@Id
	@GeneratedValue(generator = "generator")

	@Column(name = "UserId", unique = true, nullable = false)
	public Integer getUserId() {
		return this.userId;
	}

	public void setUserId(Integer userId) {
		this.userId = userId;
	}

	@ManyToOne(fetch = FetchType.LAZY)
	@PrimaryKeyJoinColumn
	@JoinColumn(name = "RoleId", nullable = false)
	public Role getRole() {
		return this.role;
	}

	public void setRole(Role role) {
		this.role = role;
	}

	@Column(name = "Username", nullable = false, length = 45)
	public String getUsername() {
		return this.username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	@Column(name = "Password", nullable = false, length = 100)
	public String getPassword() {
		return this.password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "TimeCreate", length = 19)
	public Date getTimeCreate() {
		return this.timeCreate;
	}

	public void setTimeCreate(Date timeCreate) {
		this.timeCreate = timeCreate;
	}

	@Column(name = "FullName", nullable = false, length = 45)
	public String getFullName() {
		return this.fullName;
	}

	public void setFullName(String fullName) {
		this.fullName = fullName;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "DateOfBirth", nullable = false, length = 19)
	public Date getDateOfBirth() {
		return this.dateOfBirth;
	}

	public void setDateOfBirth(Date dateOfBirth) {
		this.dateOfBirth = dateOfBirth;
	}

	@Column(name = "Email", nullable = false, length = 45)
	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	@Column(name = "Phone", nullable = false, length = 45)
	public String getPhone() {
		return this.phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}

	@OneToMany(fetch = FetchType.LAZY, mappedBy = "account")
	public Set<Subject> getSubjects() {
		return this.subjects;
	}

	public void setSubjects(Set<Subject> subjects) {
		this.subjects = subjects;
	}

}
