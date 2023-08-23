<script lang="ts">
	import { space } from 'svelte/internal';

	let email = '';
	let pass = '';
	$: passsT = pass === passs;
	let passs = '';
	let pressed = false;
</script>

<main>
	<h1>Zaregistrujte se</h1>
	<form action="?/register" method="POST" class="auth-form">
		<label for=""> Email </label>
		<input type="text" name="email" bind:value={email} placeholder="john@gmail.com" />
		{#if !email.match(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*|\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/gm) && pressed}
			<p>Email není zadán ve správném formátu</p>
		{/if}
		<label for=""> Heslo </label>
		<input type="password" name="password" bind:value={pass} />
		<div>

			{#if pass.length >= 6}
			
				{#if pass.match(/[\d]/)}

					{#if pass.match(/[^\w]/)}
						<span style="color: green;">Silné</span>
					{:else}
						<span style="color: orange;">Středně silné</span>
					{/if}

				{:else}
					<span style="color: yellow;">Minimálně silné</span>
				{/if}

			{:else if pass.length>=1}
				<span>Síla hesla</span>
				<span style="color: red;">Moc krátké!</span>
			{/if}
			</div>
			<label for=""> Znovu zadejte své heslo </label>
			<input type="password" name="password" bind:value={passs} />
			{#if passs.length>=1&& passsT}
				<p style="color: green;">Hesla se schodují</p>
				{:else if passs.length>=1&& !passsT}
				<p style="color: red;">Hesla se neschodují</p>

			{/if}
			{#if passsT && pass.length >= 6 &&email.match(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*|\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/gm)}
				<button class="btn btn-primary">Zaregistrovat</button>
				{:else}
				<p class="fake">Zaregistrovat</p>
			{/if}
	</form>
</main>
<style>
	.fake{
		background-color: grey;
	}
</style>
