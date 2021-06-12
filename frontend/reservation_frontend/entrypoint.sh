#!/bin/sh
JSON_STRING='window.configs = { \
  "VUE_APP_BACKEND":"'"${VUE_APP_BACKEND}"'", \
}'
sed -i "s@// CONFIGURATIONS_PLACEHOLDER@${JSON_STRING}@" /app/dist/index.html
exec "$@"