package com.nvn.entities;
// Generated Jan 18, 2020 4:07:11 PM by Hibernate Tools 3.5.0.Final

import java.util.HashSet;
import java.util.Set;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import static javax.persistence.GenerationType.IDENTITY;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;

@Entity
@Table(name = "SUBJECT")
public class Subject implements java.io.Serializable {

	private static final long serialVersionUID = 1L;
	
	private Integer subjectId;
	private Account account;
	private Category category;
	private String subjectName;
	private Set<Lesson> lessons = new HashSet<Lesson>(0);

	public Subject() {
	}

	public Subject(Account account, Category category, String subjectName) {
		this.account = account;
		this.category = category;
		this.subjectName = subjectName;
	}

	public Subject(Account account, Category category, String subjectName, Set<Lesson> lessons) {
		this.account = account;
		this.category = category;
		this.subjectName = subjectName;
		this.lessons = lessons;
	}

	@Id
	@GeneratedValue(strategy = IDENTITY)

	@Column(name = "SubjectId", unique = true, nullable = false)
	public Integer getSubjectId() {
		return this.subjectId;
	}

	public void setSubjectId(Integer subjectId) {
		this.subjectId = subjectId;
	}

	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "UserId", nullable = false)
	public Account getAccount() {
		return this.account;
	}

	public void setAccount(Account account) {
		this.account = account;
	}

	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "CategoryId", nullable = false)
	public Category getCategory() {
		return this.category;
	}

	public void setCategory(Category category) {
		this.category = category;
	}

	@Column(name = "SubjectName", nullable = false, length = 45)
	public String getSubjectName() {
		return this.subjectName;
	}

	public void setSubjectName(String subjectName) {
		this.subjectName = subjectName;
	}

	@OneToMany(fetch = FetchType.LAZY, mappedBy = "subject")
	public Set<Lesson> getLessons() {
		return this.lessons;
	}

	public void setLessons(Set<Lesson> lessons) {
		this.lessons = lessons;
	}

}
