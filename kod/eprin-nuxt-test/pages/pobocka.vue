<script setup lang="ts">
    definePageMeta({ middleware: 'auth' })
    const props = defineProps(['wasteCompanyBranch'])
</script>
<script setup>

</script>
<template>
    <WorkersTableSelf v-if="props?.wasteCompanyBranch" :wasteCompanyBranch="props.wasteCompanyBranch"/>
</template>