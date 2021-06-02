package com.nvn.entities;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.AttributeOverride;
import javax.persistence.AttributeOverrides;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.EmbeddedId;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import com.fasterxml.jackson.annotation.JsonIgnore;

@Entity
@Table(name = "LESSON")
public class Lesson implements Serializable{

	private static final long serialVersionUID = 1L;
	
	private LessonId id;
	private Subject subject;
	private String title;
	private String image;
	private String content;
	private String shortContent;
	private Date timeCreate;
	private Date timeUpdate;

	public Lesson() {
	}

	public Lesson(LessonId id, Subject subject, String title, String image, String content) {
		this.id = id;
		this.subject = subject;
		this.title = title;
		this.image = image;
		this.content = content;
	}

	public Lesson(LessonId id, Subject subject, String title, String image, String content,
			String shortContent, Date timeCreate, Date timeUpdate, Integer view) {
		this.id = id;
		this.subject = subject;
		this.title = title;
		this.image = image;
		this.content = content;
		this.shortContent = shortContent;
		this.timeCreate = timeCreate;
		this.timeUpdate = timeUpdate;
	}

	@EmbeddedId
	@AttributeOverrides({
			@AttributeOverride(name = "subjectId", column = @Column(name = "SubjectId", nullable = false)),
			@AttributeOverride(name = "url", column = @Column(name = "Url", nullable = false, length = 100)) })
	public LessonId getId() {
		return this.id;
	}

	public void setId(LessonId id) {
		this.id = id;
	}

	@JsonIgnore
	@ManyToOne(fetch = FetchType.LAZY, cascade=CascadeType.ALL)
	@JoinColumn(name = "SubjectId", nullable = false, insertable = false, updatable = false)
	public Subject getSubject() {
		return this.subject;
	}

	public void setSubject(Subject subject) {
		this.subject = subject;
	}

	@Column(name = "Title", nullable = false, length = 100)
	public String getTitle() {
		return this.title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	@Column(name = "Image", nullable = false, length = 100)
	public String getImage() {
		return this.image;
	}

	public void setImage(String image) {
		this.image = image;
	}

	@Column(name = "Content", nullable = false)
	public String getContent() {
		return this.content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	@Column(name = "ShortContent", length = 500)
	public String getShortContent() {
		return this.shortContent;
	}

	public void setShortContent(String shortContent) {
		this.shortContent = shortContent;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "TimeCreate", length = 19)
	public Date getTimeCreate() {
		return this.timeCreate;
	}

	public void setTimeCreate(Date timeCreate) {
		this.timeCreate = timeCreate;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "TimeUpdate", length = 19)
	public Date getTimeUpdate() {
		return this.timeUpdate;
	}

	public void setTimeUpdate(Date timeUpdate) {
		this.timeUpdate = timeUpdate;
	}

}
