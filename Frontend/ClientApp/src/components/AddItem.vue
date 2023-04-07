<script setup lang="ts">
import { ref } from 'vue';
const emit = defineEmits(["add"]);

const title = ref<string>();
const end_date = ref<string>();

function SubmitForm() {
  const Title = title.value;
  const EndDate = end_date.value;
  const checkDate = new Date(EndDate)
  const currentDay = new Date();

  console.log(EndDate)

  if (checkDate > currentDay) {
    emit("add", Title, EndDate);
  }


}
</script>

<template>
  <form v-on:submit.prevent="SubmitForm">
    <div>
      <label for="title">Title: </label>
      <input type="text" name="title" id="title" v-model="title">
    </div>
    <div>
      <label for="endDate">End Date: </label>
      <input type="date" id="endDate" v-model="end_date">
    </div>
    <button type="submit">Submit</button>
  </form>
</template>
