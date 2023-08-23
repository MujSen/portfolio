<script lang="ts">
	import type { PageData } from './$types'

	// Deklarace proměnných
	export let data: PageData
	$: ({ article } = data)
</script>

<form action="?/updateArticle" method="POST">
	<h3>Úprava: {article.title}</h3>
	<label for="title">Titulek:</label>
	<input type="text" id="title" name="title" value={article.title} />
	<label for="content">Obsah:</label>
	<textarea id="content" name="content" rows={5} value={article.content} />
	<button type="submit">Změnit zprávu</button>
</form>
