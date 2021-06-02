package com.nvn.entities;

import javax.persistence.Column;
import javax.persistence.Embeddable;

@Embeddable
public class LessonId implements java.io.Serializable {

	private static final long serialVersionUID = 1L;
	
	private int subjectId;
	private String url;

	public LessonId() {
	}

	public LessonId(int subjectId, String url) {
		this.subjectId = subjectId;
		this.url = url;
	}

	@Column(name = "SubjectId", nullable = false)
	public int getSubjectId() {
		return this.subjectId;
	}

	public void setSubjectId(int subjectId) {
		this.subjectId = subjectId;
	}

	@Column(name = "Url", nullable = false, length = 100)
	public String getUrl() {
		return this.url;
	}

	public void setUrl(String url) {
		this.url = url;
	}

	public boolean equals(Object other) {
		if ((this == other))
			return true;
		if ((other == null))
			return false;
		if (!(other instanceof LessonId))
			return false;
		LessonId castOther = (LessonId) other;

		return (this.getSubjectId() == castOther.getSubjectId()) && ((this.getUrl() == castOther.getUrl())
				|| (this.getUrl() != null && castOther.getUrl() != null && this.getUrl().equals(castOther.getUrl())));
	}

	public int hashCode() {
		int result = 17;

		result = 37 * result + this.getSubjectId();
		result = 37 * result + (getUrl() == null ? 0 : this.getUrl().hashCode());
		return result;
	}

}
