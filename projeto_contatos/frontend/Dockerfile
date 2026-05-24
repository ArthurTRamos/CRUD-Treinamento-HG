# --------------- STAGE 1: BUILD ---------------
FROM node:20-alpine AS build
WORKDIR /app

# Copia manifests de dependencias primeiro (cache!)
COPY package.json package-lock.json ./
RUN npm install

# Copia o codigo e faz o build de producao
COPY . .
RUN npm run build

# --------------- STAGE 2: serve com nginx ---------------
FROM nginx:alpine AS final

# Copia os arquivos estaticos gerados para o diretorio do Nginx
COPY --from=build /app/dist/Lista-Telefonica/browser /usr/share/nginx/html

# (Opcional) Configuracao customizada para SPA - fallback para index.html
COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 8080
CMD ["nginx", "-g", "daemon off;"]