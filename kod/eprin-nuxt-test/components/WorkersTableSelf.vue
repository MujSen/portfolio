<script setup>
const branchData = ref(null);
const errorData = ref(false);
const isPending = ref(false);
//const wasteCompanyBranch = useCookie('wasteCompanyBranch');
const props = defineProps(['wasteCompanyBranch'])

async function getData() {
    const { data, error, pending } = await useFetch('/api/wastecompany/workers/getOwnBranchInfo');
    if (error.value) {
        errorData = error.value;
    }
    branchData.value = data.value.data;
    isPending.value = pending.value;
}

getData()
</script>
<template>
    <div class="pobocka">
        <img v-if="props?.wasteCompanyBranch?.logoUrl" :src="'https://api-ts-dev.jrkdigital.eu/' + props.wasteCompanyBranch.logoUrl"
            alt="logo pobočky">
        <p>{{ props.wasteCompanyBranch.name }}</p>
    </div>
    <h1>Výpis zaměstnanců</h1>
    <div class="pending" v-if="isPending">
        <div class="three-body">
            <div class="three-body__dot"></div>
            <div class="three-body__dot"></div>
            <div class="three-body__dot"></div>
        </div>
    </div>
    <table v-if="branchData">
        <thead>
            <tr>
                <th>Pracovní číslo</th>
                <th>Jméno</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="worker in branchData">
                <td>{{ worker.id }}</td>
                <td>{{ worker.fullName }}</td>
            </tr>
        </tbody>
    </table>
    <p v-if="errorData">{{ errorData }}</p>
    <button @click="() => { getData() }">Aktualizovat</button>
</template>
<style scoped>
.pobocka{
    align-self: center;
}
table {
    align-self: center;
    text-align: center;
    width: fit-content;
}

table th,
table td {
    padding: 15px;
    font-weight: bold;
}

h1 {
    align-self: center;
    font-weight: 500;
    color: #86BB47;
    font-size: 2rem;
}

ul {
    display: flex;
    flex-direction: column;
    align-items: center;
}

ul li {
    padding: 25px 30px;
}

ul li:hover {
    background-color: #86BB47;
}

button {
    align-self: center;
    font-weight: bold;
    color: #fff;
    padding: 10px 40px;
    border-radius: 5px;
    background-color: #86BB47;
    transition: background-color 0.4s ease-in-out;
    width: fit-content;
}

button:hover {
    background-color: #6CB416;
}

table tr {
    transition: background-color 0.4s ease-in-out;
}

table tr:hover {
    background-color: #86BB47;
}

.three-body {
    --uib-size: 35px;
    --uib-speed: 0.8s;
    --uib-color: #86BB47;
    position: relative;
    display: inline-block;
    height: var(--uib-size);
    width: var(--uib-size);
    animation: spin78236 calc(var(--uib-speed) * 2.5) infinite linear;
}

.three-body__dot {
    position: absolute;
    height: 100%;
    width: 30%;
}

.three-body__dot:after {
    content: '';
    position: absolute;
    height: 0%;
    width: 100%;
    padding-bottom: 100%;
    background-color: var(--uib-color);
    border-radius: 50%;
}

.three-body__dot:nth-child(1) {
    bottom: 5%;
    left: 0;
    transform: rotate(60deg);
    transform-origin: 50% 85%;
}

.three-body__dot:nth-child(1)::after {
    bottom: 0;
    left: 0;
    animation: wobble1 var(--uib-speed) infinite ease-in-out;
    animation-delay: calc(var(--uib-speed) * -0.3);
}

.three-body__dot:nth-child(2) {
    bottom: 5%;
    right: 0;
    transform: rotate(-60deg);
    transform-origin: 50% 85%;
}

.three-body__dot:nth-child(2)::after {
    bottom: 0;
    left: 0;
    animation: wobble1 var(--uib-speed) infinite calc(var(--uib-speed) * -0.15) ease-in-out;
}

.three-body__dot:nth-child(3) {
    bottom: -5%;
    left: 0;
    transform: translateX(116.666%);
}

.three-body__dot:nth-child(3)::after {
    top: 0;
    left: 0;
    animation: wobble2 var(--uib-speed) infinite ease-in-out;
}

@keyframes spin78236 {
    0% {
        transform: rotate(0deg);
    }

    100% {
        transform: rotate(360deg);
    }
}

@keyframes wobble1 {

    0%,
    100% {
        transform: translateY(0%) scale(1);
        opacity: 1;
    }

    50% {
        transform: translateY(-66%) scale(0.65);
        opacity: 0.8;
    }
}

@keyframes wobble2 {

    0%,
    100% {
        transform: translateY(0%) scale(1);
        opacity: 1;
    }

    50% {
        transform: translateY(66%) scale(0.65);
        opacity: 0.8;
    }
}
</style>