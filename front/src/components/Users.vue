<template>
    <div>
        <ul>
            
           <User v-for="user in users" 
           v-bind:user="user"
           :key="user.id"></User>
                
           
        </ul>
    </div>
</template>

<script>
import User from '@/components/User.vue'
export default {
    props: ['users'],
    components: {
        User
    }
}
</script>