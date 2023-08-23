<script lang="ts">
	import '@picocss/pico'
	import type { PageData } from './$types'
	export let data: PageData
</script>

<div class="container-full">
	<nav>
		<ul>
			<li>
				<strong>
					<a href="/"> Zprávařina </a>
				</strong>
			</li>
		</ul>
		<ul>
			<form method="POST">
				<li><a href="/">Domů</a></li>
				{#if !data.user}
					<li><a href="/register">Zaregistrovat</a></li>
					<li><a href="/login">Přihlásit</a></li>
				{:else}
					<li>
						<button formaction="/logout" type="submit">Odhlásit</button>
					</li>
				{/if}
			</form>
		</ul>
	</nav>
	<slot />
</div>
<style>
	.container-full{
		background-image: url('https://picsum.photos/800/600');
		background-color: rgb(117, 111, 111);
		background-blend-mode: multiply;
		background-repeat: no-repeat;
		background-size: cover;
		min-height: 100vh;
	}
	nav{
		background-color: rgba(17, 16, 16, 0.473);
		padding: 0 10px;
	}
</style>