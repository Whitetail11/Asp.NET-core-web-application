<template>
    <li>
        {{user.nickname}}
    </li>
</template>

<script>

export default {
    props: {
        user: {
            type: Object,
            required: true
        }
    }
}
</script>