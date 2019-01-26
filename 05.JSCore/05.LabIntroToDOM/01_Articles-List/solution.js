function createArticle() {
	let title = document.getElementById('createTitle').value
	let text = document.getElementById('createContent').value
	let articlesList = document.getElementById('articles')

	if (title !== '' && text !== '') {

		let article = document.createElement('article')
		let h3 = document.createElement('h3')
		h3.textContent = title
		let p = document.createElement('p')
		p.textContent = text
		article.appendChild(h3)
		article.appendChild(p)
		articlesList.appendChild(article)
	}
	
	document.getElementById('createTitle').value = ""
	document.getElementById('createContent').value = ""
}