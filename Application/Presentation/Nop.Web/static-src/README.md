# Gulp Front


## Quick Start

### Install [node.js](https://nodejs.org)

### Install [git](https://git-for-windows.github.io/)

### Install **Gulp** globally (once!)

```sh
$ npm install gulp -g
```
### Install **Bower** globally (once!)

```sh
$ npm install -g bower
```

### Install dependencies (once for a project)

```sh
$ npm install
```

```sh
$ bower install
```

## Static pages development with Gulp

```sh
$ npm start
```

Serves static pages at [`http://localhost:3000/`](http://localhost:3000/) in development mode

## Vue app development

```sh
$ npm run serve
```
App will run at [`http://localhost:8080`](http://localhost:8080) in development mode

## Website production

```sh
$ npm run prod
```

Builds the app and static pages to `dist`

## Vue app production

```sh
$ npm run build
```
Builds the app to `src/app/dist`

## Main gulp tasks

* `gulp`	=	`gulp develop` 
* `gulp develop`	- runs watchers and server and distributes to `dist` 
* `gulp sprite:retina`	- builds retina sprite
* `gulp sprite:svg`	- builds svg sprite
* `gulp sprite:default`	- builds default sprite
* `gulp production`	- builds the project and distributes to `dist` 

## NPM scripts

* `serve`	- runs vue app on [`http://localhost:8080`](http://localhost:8080),
* `build` - builds the vue app for production into `src/app/dist`,
* `dev`- builds the vue app, then copies `src/app/dist` folder to `dist/app` and runs `gulp develop`,
* `prod`- builds the vue app, then copies `src/app/dist` folder to `dist/app` and runs `gulp production`,
* `start` - runs `dev`


