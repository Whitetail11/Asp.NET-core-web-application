<template>
    <div>
        <ul>
            
           <UserItem
            v-for="user in users" 
            v-bind:user="user">
            </UserItem>
                
           
        </ul>
    </div>
</template>

<script>
import UserItem from '@/components/UserItem.vue'
export default {
    props: ['users'],
    components: {
        UserItem
    }
}
</script>