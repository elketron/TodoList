<script setup lang="ts">
import { PropType, ref, ComputedRef, computed } from 'vue';
import { TodoItem } from '../Item';

const emit = defineEmits(["delete", "done"])

const props = defineProps({
  todo_item: Object as PropType<TodoItem>,
})

function formatDate(date_string: string | undefined) {
  if (date_string === undefined) {
    return ""
  }

  let re = /(\d{4})-(\d{2})-(\d{2})/;
  let res: any = re.exec(date_string);

  return `${res[3]}/${res[2]}/${res[1]}`;
}

</script>

<template>
  <td>{{ todo_item?.title }}</td>
  <td>{{ formatDate(todo_item?.endDate) }}</td>
  <td>{{ todo_item?.done }}</td>
  <td>
    <input type="button" name="delete" id="delete" value="Delete" @click="() => emit('delete', todo_item?.id)">
    |
    <input type="button" name="done" id="done" value="Toggle Done" @click="() => emit('done', todo_item?.id)">
  </td>
</template>
