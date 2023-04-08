<script setup lang="ts">
import axios from "axios";
import { v4 as uuid } from "uuid";
import { onMounted, ref } from "vue";
import { TodoItem as Item } from './Item';
import TodoItem from "./components/TodoItem.vue";
import AddItem from "./components/AddItem.vue";

const todo_items = ref<Array<Item>>();
async function getAll() {
  await axios.get("/api/todolist").then(function (response) {
    todo_items.value = response.data;
  })
}

async function Add(title: string, end_date: string) {
  const item: Item = {
    id: uuid(),
    title: title,
    done: false,
    endDate: end_date
  }

  await axios.post("/api/todolist", item).catch((error) => console.error(error))
  await getAll()
}

async function Delete(id: string) {
  await axios.delete(`/api/todolist/${id}`)
    .catch((error) => console.error(error));
  await getAll()
}

async function Done(id: string) {
  let item = todo_items.value?.find(i => i.id === id);

  if (item != undefined) {
    item.done = !item.done;
    await axios.post("/api/todolist/done", item)
      .catch((error) => console.error(error)
      )
  }

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
