<script lang="ts">
	import type { PageData } from './$types'

	export let data: PageData
	// Funkce pro výpočet rozdílu času
	function calculateDateDiff(last_update) {
		let dateObject = new Date(last_update);
		let currentDate = new Date();
		let miliDifference = currentDate.getTime() - dateObject.getTime();

		let units = [
			{ unit: "rok", singular: "rok", plural: "roky", divisor: 365 * 24 * 60 * 60 * 1000 },
			{ unit: "den", singular: "den", plural: "dny", divisor: 24 * 60 * 60 * 1000 },
			{ unit: "hodin", singular: "hodinou", plural: "hodiny", divisor: 60 * 60 * 1000 },
			{ unit: "minut", singular: "minutou", plural: "minuty", divisor: 60 * 1000 },
			{ unit: "sekund", singular: "sekundou", plural: "sekundy", divisor: 1000 }
		];

		let result = "";

		for (let { unit, singular, plural, divisor } of units) {
			let count = Math.floor(miliDifference / divisor);
			if (count > 0) {
				result += `${count} ${count === 1 ? singular : plural} `;
				miliDifference -= count * divisor;
			}
		}
		return result.trim();
	}

	// Automatická reaktivace dat při změně
	$: ({ articles } = data)

</script>


<div class="grid">
	<div>
		<h2>Zprávy:</h2>
		{#each articles as article}
			<article>
				<header>{article.title}</header>
				<p>
					{article.content}
				</p>
				{#if article.userId === data.user?.userId}
					<form action="?/deleteArticle&id={article.id}" method="POST">
						<button type="submit" class="outline secondary">Delete Article</button>
					</form>
					<a href="/{article.id}" role="button" class="outline constrast" style="width: 100%;"
						>Zprávy od uživatelů</a
					>
				{/if}
				<p>
					Naposledy upraveno před: {calculateDateDiff(article.last_update)}
				</p>
			</article>
		{/each}
	</div>
	{#if data.user}
		<form action="?/createArticle" method="POST">
			<h3>Nová zpráva</h3>
			<label for="title"> Titulek </label>
			<input type="text" id="title" name="title" />
			<label for="title"> Obsah </label>
			<textarea id="content" name="content" rows={5} />
			<button type="submit">Přidat zprávu</button>
		</form>
	{/if}
</div>
<style>
	.grid{
		padding: 20px;
	}
</style>