<template>
    <div>
        <button v-on:click ="adduser">
            add user
        </button>
    </div>
</template>

<script>
export default {
    props: ['users'],
    data() {
        return {
             user: {Id: 1, Email: 'NEW USER9', Password: '444', NickName: 'NEW USER9', Age: 12}
        }
    },
    methods: {
        adduser() {
             fetch('https://localhost:5001/api/user', {
                method: 'POST',
                 headers: {
    'Content-Type': 'application/json;charset=utf-8'
  },
                body: JSON.stringify(this.user)
            }); 
            this.users.push(this.user);  
        }
    }
}
</script>