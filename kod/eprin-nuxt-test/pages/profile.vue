<template>
    <div>I'm protected!</div>
</template>
<script setup lang="ts">
definePageMeta({ middleware: 'auth',layout: 'default' })
</script>