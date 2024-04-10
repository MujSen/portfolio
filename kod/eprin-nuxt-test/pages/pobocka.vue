<script setup lang="ts">
    definePageMeta({ middleware: 'auth' })
    const props = defineProps(['wasteCompanyBranch'])
</script>
<script setup>

</script>
<template>
    <WorkersTableSelf :wasteCompanyBranch="props.wasteCompanyBranch"/>
</template>