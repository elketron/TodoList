<script setup lang="ts">
import axios from "axios";
import { v4 as uuid } from "uuid";
import { onMounted, ref } from "vue";
import { TodoItem as Item } from './Item';
import TodoItem from "./components/TodoItem.vue";
import AddItem from "./components/AddItem.vue";

const todo_items = ref<Array<Item>>();
function getAll() {
  axios.get("/api/todolist").then(function (response) {
    todo_items.value = response.data;
  })
}

function Add(title: string, end_date: string) {
  const item: Item = {
    id: uuid(),
    title: title,
    done: false,
    endDate: end_date
  }

  axios.post("/api/todolist", item)
  getAll()
}

function Delete(id: string) {
  axios.delete(`/api/todolist/${id}`);
  getAll()
}

function Done(id: string) {

}

onMounted(() => {
  getAll();
})

</script>

<template>
  <AddItem @add="Add" />

  <table class="min-w-full text-left text-sm font-light">
    <thead class="border-b bg-white dark:border-neutral-500 dark:bg-neutral-600">
      <tr class="border-b bg-neutral-100 dark:border-neutral-500 dark:bg-neutral-700">
        <th>Title</th>
        <th>End date</th>
        <th>Done</th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      <tr class="border-b bg-neutral-100 dark:border-neutral-500 dark:bg-neutral-700" v-for="todo in todo_items">
        <TodoItem :todo_item="todo" @done="Done" @delete="Delete" />
      </tr>
    </tbody>
  </table>
</template>
<style scoped></style>
