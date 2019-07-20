var routes = [
    // default routes
    { path: "/", redirect: (function (to) { return "/dashboard"; }) },
    { path: "/dashboard", component: dashboardComponent, meta: { title: "Dashboard" } },
    { path: '*', component: dashboardComponent },

    //// calculate npv
    { path: "/calculate", component: npvFormComponent, meta: { title: "Calculate NPV" } },

    { path: "/calculate/result/:id", component: npvFormComponent, meta: { title: "NPV Result" } }
];