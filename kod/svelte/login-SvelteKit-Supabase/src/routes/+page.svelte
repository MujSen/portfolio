<script lang="ts">
	import { enhance, type SubmitFunction } from '$app/forms';
	import { supabaseClient } from '$lib/supabase';
	import type { PageData } from './$types';
	import { redirect } from '@sveltejs/kit';


	let retnum = 5;
	
	function timeout(){
		let interv = setInterval(()=>{
			if (retnum==1) {
			clearInterval(interv);
			redirect(300,'/home');
			}
			retnum--;
		},1000)
		return "sec";
	}
	export let data: PageData;

	const submitLogout: SubmitFunction = async ({ cancel }) => {
		const { error } = await supabaseClient.auth.signOut();
		if (error) {
			console.log(error);
		}
		cancel();
	};
	import type { Provider } from '@supabase/supabase-js';

	const signInWithProvider = async (provider: Provider) => {
		const { data, error } = await supabaseClient.auth.signInWithOAuth({
			provider: provider
		});
	};

	const submitSocialLogin: SubmitFunction = async ({ action, cancel }) => {
		switch (action.searchParams.get('provider')) {
			case 'google':
				await signInWithProvider('google');
				break;
			case 'discord':
				await signInWithProvider('discord');
				break;
			case 'github':
				await signInWithProvider('github');
				break;
			default:
				break;
		}
		cancel();
	};
</script>

<article>
	<section>
		<p>Technologie</p>
		<ul>
			<li>SvelteKit - framework pro Frontend + Backend (middleframework) ⚙️</li>
			<li>Supabase - databáze 📅</li>
		</ul>
		<p>Díváte se na aplikaci jenž má dokončené</p>
		<ul>
			<li>user authentikaci 🫡</li>
		</ul>
	</section>
	<section>
		<h1>Vítejte zpět v super webApp</h1>
		{#if data.session}
			<p>Vítej zpět, {data.session.user.email}</p>
			<form action="/logout" method="POST" use:enhance={submitLogout}>
				<button type="submit" class="redd">Odhlásit se</button>
			</form>
			<p>Přesměrovávám na hlavní stránku za {retnum} {timeout()}</p>
			<a href="/home">home</a>
		{:else}
			<p>Přihlaste se</p>
			<div>
				<form on:submit|preventDefault method="POST">
					<label for=""> Email </label>
					<input type="text" name="email" />
					<label for=""> Heslo </label>
					<input type="password" name="password" />
					<button type="submit">Login</button>
				</form>
				<form method="POST" use:enhance={submitSocialLogin}>
					<button formaction="?/login&provider=github">
						<svg
							width="1024"
							height="1024"
							viewBox="0 0 1024 1024"
							fill="none"
							xmlns="http://www.w3.org/2000/svg"
						>
							<path
								fill-rule="evenodd"
								clip-rule="evenodd"
								d="M8 0C3.58 0 0 3.58 0 8C0 11.54 2.29 14.53 5.47 15.59C5.87 15.66 6.02 15.42 6.02 15.21C6.02 15.02 6.01 14.39 6.01 13.72C4 14.09 3.48 13.23 3.32 12.78C3.23 12.55 2.84 11.84 2.5 11.65C2.22 11.5 1.82 11.13 2.49 11.12C3.12 11.11 3.57 11.7 3.72 11.94C4.44 13.15 5.59 12.81 6.05 12.6C6.12 12.08 6.33 11.73 6.56 11.53C4.78 11.33 2.92 10.64 2.92 7.58C2.92 6.71 3.23 5.99 3.74 5.43C3.66 5.23 3.38 4.41 3.82 3.31C3.82 3.31 4.49 3.1 6.02 4.13C6.66 3.95 7.34 3.86 8.02 3.86C8.7 3.86 9.38 3.95 10.02 4.13C11.55 3.09 12.22 3.31 12.22 3.31C12.66 4.41 12.38 5.23 12.3 5.43C12.81 5.99 13.12 6.7 13.12 7.58C13.12 10.65 11.25 11.33 9.47 11.53C9.76 11.78 10.01 12.26 10.01 13.01C10.01 14.08 10 14.94 10 15.21C10 15.42 10.15 15.67 10.55 15.59C13.71 14.53 16 11.53 16 8C16 3.58 12.42 0 8 0Z"
								transform="scale(64)"
								fill="#1B1F23"
							/>
						</svg>
						Github</button
					>
					<button formaction="?/login&provider=discord">
						<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 127.14 96.36"
							><defs
								><style>
									.cls-1 {
										fill: #5865f2;
									}
								</style></defs
							><g id="图层_2" data-name="图层 2"
								><g id="Discord_Logos" data-name="Discord Logos"
									><g id="Discord_Logo_-_Large_-_White" data-name="Discord Logo - Large - White"
										><path
											class="cls-1"
											d="M107.7,8.07A105.15,105.15,0,0,0,81.47,0a72.06,72.06,0,0,0-3.36,6.83A97.68,97.68,0,0,0,49,6.83,72.37,72.37,0,0,0,45.64,0,105.89,105.89,0,0,0,19.39,8.09C2.79,32.65-1.71,56.6.54,80.21h0A105.73,105.73,0,0,0,32.71,96.36,77.7,77.7,0,0,0,39.6,85.25a68.42,68.42,0,0,1-10.85-5.18c.91-.66,1.8-1.34,2.66-2a75.57,75.57,0,0,0,64.32,0c.87.71,1.76,1.39,2.66,2a68.68,68.68,0,0,1-10.87,5.19,77,77,0,0,0,6.89,11.1A105.25,105.25,0,0,0,126.6,80.22h0C129.24,52.84,122.09,29.11,107.7,8.07ZM42.45,65.69C36.18,65.69,31,60,31,53s5-12.74,11.43-12.74S54,46,53.89,53,48.84,65.69,42.45,65.69Zm42.24,0C78.41,65.69,73.25,60,73.25,53s5-12.74,11.44-12.74S96.23,46,96.12,53,91.08,65.69,84.69,65.69Z"
										/></g
									></g
								></g
							></svg
						>Discord</button
					>
					<button formaction="?/login&provider=google">
						<svg
							xmlns="http://www.w3.org/2000/svg"
							width="705.6"
							height="720"
							viewBox="0 0 186.69 190.5"
							><g transform="translate(1184.583 765.171)"
								><path
									clip-path="none"
									mask="none"
									d="M-1089.333-687.239v36.888h51.262c-2.251 11.863-9.006 21.908-19.137 28.662l30.913 23.986c18.011-16.625 28.402-41.044 28.402-70.052 0-6.754-.606-13.249-1.732-19.483z"
									fill="#4285f4"
								/><path
									clip-path="none"
									mask="none"
									d="M-1142.714-651.791l-6.972 5.337-24.679 19.223h0c15.673 31.086 47.796 52.561 85.03 52.561 25.717 0 47.278-8.486 63.038-23.033l-30.913-23.986c-8.486 5.715-19.31 9.179-32.125 9.179-24.765 0-45.806-16.712-53.34-39.226z"
									fill="#34a853"
								/><path
									clip-path="none"
									mask="none"
									d="M-1174.365-712.61c-6.494 12.815-10.217 27.276-10.217 42.689s3.723 29.874 10.217 42.689c0 .086 31.693-24.592 31.693-24.592-1.905-5.715-3.031-11.776-3.031-18.098s1.126-12.383 3.031-18.098z"
									fill="#fbbc05"
								/><path
									d="M-1089.333-727.244c14.028 0 26.497 4.849 36.455 14.201l27.276-27.276c-16.539-15.413-38.013-24.852-63.731-24.852-37.234 0-69.359 21.388-85.032 52.561l31.692 24.592c7.533-22.514 28.575-39.226 53.34-39.226z"
									fill="#ea4335"
									clip-path="none"
									mask="none"
								/></g
							></svg
						>Google</button
					>
				</form>
			</div>
			<p>nebo</p>
			<a href="/register">Vytvořit si účet</a>
		{/if}
	</section>
</article>

<style>
	article {
		display: flex;
		flex-wrap: wrap;
		width: 100%;
		height: 100%;
	}
	form button svg {
		width: auto;
		height: 50%;
	}
	section {
		min-width: 600px;
		width: 50%;
	}
	@media only screen and (max-width: 1200px) {
		section {
			width: 100%;
		}
	}
	section:first-of-type {
		background-image: url('https://picsum.photos/800/600');
		background-color: grey;
		background-blend-mode: multiply;
		background-repeat: no-repeat;
		background-size: cover;
	}
	div {
		width: 90%;
	}
	form {
		width: 100%;
	}
	form:first-of-type {
		display: flex;
		flex-flow: column;
	}
	form:last-of-type {
		display: flex;
		flex-flow: row;
		justify-content: space-around;
	}
	section:last-of-type {
		align-items: center;
		justify-content: center;
		display: flex;
		flex-flow: column;
	}
	form:first-of-type button{
		width: 30%;
		margin: 0 auto;
	}
	form:first-of-type button{
		background: linear-gradient(to right, #19333f, #203a43, #2c5364); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
		color: red;
	}
	form:last-of-type button {
		height: 50px;
		display: flex;
		border-radius: 100px;
		align-items: center;
		justify-content: center;
		cursor: pointer;
		position: relative;
    	z-index: 0;
		border: none;
		margin: 10px 0;
	}
	form:last-of-type button:before {
    content: '';
    background: linear-gradient(45deg, #ff0000, #ff7300, #fffb00, #48ff00, #00ffd5, #002bff, #7a00ff, #ff00c8, #ff0000);
    position: absolute;
    top: -2px;
    left:-2px;
    background-size: 400%;
    z-index: -1;
    filter: blur(5px);
    width: calc(100% + 4px);
    height: calc(100% + 4px);
    animation: glowing 20s linear infinite;
    opacity: 0;
    transition: opacity .3s ease-in-out;
    border-radius: 10px;
}

form:last-of-type button:active {
    color: #000;
}

form:last-of-type button:active:after {
    background: transparent;
}

form:last-of-type button:hover:before {
    opacity: 1;
}
form:last-of-type button:after {
    z-index: -1;
    content: '';
    position: absolute;
    width: 100%;
	background: #FFF;
    height: 100%;
    left: 0;
    top: 0;
    border-radius: 10px;
}
@keyframes glowing {
    0% { background-position: 0 0; }
    50% { background-position: 400% 0; }
    100% { background-position: 0 0; }
}
</style>
