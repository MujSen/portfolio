<script setup lang="ts">
const { status, data, signOut, signIn } = useAuth()
const headers = useRequestHeaders(['cookie']) as HeadersInit
const props = defineProps(['id'])
const workers = ref(null);
if (props.id && status.value === 'authenticated') {
    getWorkers(props.id);
}
async function getWorkers(id) {
    if (!id) {
        return
    }
    const { data: wasteWorkers } = await useFetch('/api/wastecompany/workers/' + id, {
        headers,
    }
    )
    workers.value = wasteWorkers.value.data
}
</script>
<template>
    <section class="m-12">
        <table v-if="workers"  class="text-white bg-slate-900">
            <thead class="align-bottom">
                <tr class="font-semibold text-[0.95rem] text-secondary-dark">
                    <td class="text-center min-w-[175px]">Jméno</td>
                    <td class="text-center min-w-[100px]">id</td>
                </tr>
            </thead>
            <tbody>
                <tr class="border-b border-dashed last:border-b-0" v-for="worker in workers" >
                    <td class="text-center font-semibold text-light-inverse text-md/normal"> {{ worker.fullName }} </td>
                    <td class="text-center font-semibold text-light-inverse text-md/normal"> {{ worker.id }} </td>
                </tr>
            </tbody>
        </table>
    </section>
</template>
<style scoped>
    /*td{
        padding: 5px;
        text-align: center;
        background-color: aliceblue;
    }
    td:nth-child(2n){
        background-color: rgb(120, 125, 129);
    }
    */
    section{
        display: flex;
        justify-content: center;
    }
    td{
        padding: 1rem;
    }
    tr:nth-child(1n){
        border-bottom: 5px solid #131a25;
    }
    tr td{
        background-image: linear-gradient(to right, #131a25, #161e2a, #1a2230, #1d2635, #212a3b, #212a3b, #212a3b, #212a3b, #1d2635, #1a2230, #161e2a, #131a25);    }
    tr td:nth-child(2n){
        box-shadow: inset 0px 0px 25px 0px #000000ec;
    }
</style>