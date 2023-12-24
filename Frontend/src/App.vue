<script>
import FooterSection from "@/public/components/footerSection.component.vue";
export default {
  name: "app",
  components: {FooterSection}
}
</script>

<template>
  <div>
     <div class="main-content">
       <router-view></router-view>
     </div>
     <footerSection></footerSection>
  </div>
</template>

<style scoped>
.main-content {
  min-height: 100vh;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}
</style>
