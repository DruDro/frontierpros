'use strict';

// Подключение плагинов
var gulp = require('gulp'),
	gulpsync = require('gulp-sync')(gulp),
	clean = require('gulp-clean'),
	sass = require('gulp-sass'),
	sourcemaps = require('gulp-sourcemaps'),
	uglify = require('gulp-uglify'),
	concat = require('gulp-concat'),
	watch = require('gulp-watch'),
	browserSync = require('browser-sync'),
	imagemin = require('gulp-imagemin'),
	pngquant = require('imagemin-pngquant'),
	spritesmith = require('gulp.spritesmith'),
	plumber = require('gulp-plumber'),
	notify = require('gulp-notify'),
	rename = require('gulp-rename'),
	svgSprite = require('gulp-svg-sprite'),
	imageResize = require('gulp-image-resize'),
	bulkSass = require('gulp-sass-glob-import'),
	include = require("gulp-include"),
	autoprefixer = require('gulp-autoprefixer'),
	removeEmptyLines = require('gulp-remove-empty-lines'),
	htmltidy = require('gulp-htmltidy'),
	htmlbeautify = require('gulp-html-beautify'),
	replace = require('gulp-replace-task'),
	fileinclude = require('gulp-file-include'),
	babel = require('gulp-babel');


//конфиги

var autoPrefixerOptions = {
	browsers: ['last 3 versions', '> 1%', 'Firefox ESR', 'ie > 8', 'safari 5', 'opera 12.1'],
	cascade: true,
}

var plumberCfg = {
	errorHandler: notify.onError({
		message: "Error: <%= error.message %>",
	})
};

var fileIncludeCfg = {
	prefix: '@@',
	basepath: '@root'
};
var formatHTML = {
	"indent_size": 2,
	"indent_char": "  ",
	"eol": "\n",
	"indent_level": 0,
	"indent_with_tabs": true,
	"preserve_newlines": true,
	"max_preserve_newlines": 10,
	"jslint_happy": false,
	"space_after_anon_function": false,
	"brace_style": "collapse",
	"keep_array_indentation": false,
	"keep_function_indentation": false,
	"space_before_conditional": true,
	"break_chained_methods": false,
	"eval_code": false,
	"unescape_strings": false,
	"wrap_line_length": 0,
	"wrap_attributes": "auto",
	"wrap_attributes_indent_size": 4,
	"end_with_newline": true
}

var imgResizeCfg = {
	width: '50%',
	height: '50%',
	crop: false,
	upscale: false
};

var spriteDefaultCfg = {
	imgName: 'sprite.png',
	cssName: '_sprite.scss',
	imgPath: '../img/sprite.png',
	padding: 5
};

var spriteMithRetinaCfg = {
	imgName: 'sprite.png',
	cssName: '_sprite.scss',
	imgPath: '../img/sprite.png',
	retinaImgName: 'sprite@2x.png',
	retinaSrcFilter: 'src/static/assets/img/sprite/retina/**/*_2x.png',
	retinaImgPath: '../img/sprite@2x.png',
	padding: 5
}

var spriteSvgCfg = {
	"mode": {
		"css": {
			"spacing": {
				"padding": 5
			},
			"dest": "./",
			"layout": "horizontal",
			"sprite": "sprite-svg.svg",
			"bust": false,
			"render": {
				"scss": {
					"dest": "_sprite-svg.scss",
				}
			}
		}
	}
}

var svgSymbol = {
	mode: {
		view: {
			bust: false
		},
		symbol: true
	}
};

// Пути для сборки
var path = {
	build: {
		root: 'dist/',
		js: 'dist/media/js/',
		css: 'dist/media/css/',
		fonts: 'dist/media/fonts/',
		img: 'dist/media/img/',
		pic: 'dist/media/img/',
		svg: 'src/static/assets/img/svg/',
		app:'dist/app/',
		html: 'dist/*.html',
		svgHtml: 'dist/media/img/',
		configs:'dist/'
	},
	src: {
		root: 'src/',
		//      html: ['src/pages/*.html', 'src/static/assets/img/svg.html'],
		app: 'src/app/dist/**/*.*',
		html: 'src/pages/*.html',
		svgHtml: 'src/static/assets/img/svg-sprite.html',
		js: 'src/static/scripts/require.js',
		styles: 'src/static/styles/',
		sass: 'src/static/styles/main.scss',
		img: ['src/static/assets/img/**/*.*', '!src/static/assets/img/sprite/**/*.*', '!src/static/assets/img/svg/**/*.*', '!src/static/assets/img/**/*.html'],
		pic: ['src/static/assets/pic/**/*.jpg', 'src/static/assets/pic/**/*.png', 'src/static/assets/pic/**/*.ico', 'src/static/assets/pic/**/*.svg', 'src/static/assets/pic/**/site.webmanifest', 'src/static/assets/pic/**/browserconfig.xml'],
		fonts: 'src/static/assets/fonts/**/*.*',
		spr: {
			default: 'src/static/assets/img/sprite/default/*.png',
			retina2x: 'src/static/assets/img/sprite/retina/2x/*.png',
			retina1x: 'src/static/assets/img/sprite/retina/1x/',
			retina: 'src/static/assets/img/sprite/retina/**/*.png',
			svg: 'src/static/assets/img/sprite/svg/**/*.svg'
		},
		modules: 'src/modules/**/*.scss',
		configs:['src/static/*.config','src/static/*.htaccess']
	},
	watch: {
		html: ['src/pages/**/*.html', 'src/modules/**/*.html'],
		configs:['src/static/*.config','src/static/*.htaccess'],
		svgHtml: 'src/static/assets/img/svg-sprite.html',
		sass: 'src/static/styles/**/*.scss',
		fonts: 'src/static/assets/fonts/**/*.*',
		js: ['src/static/scripts/**/*.js', 'src/modules/**/*.js'],
		pic: 'src/static/assets/pic/**/*.*',
		img: ['src/static/assets/img/**/*.*', '!src/static/assets/img/sprite/**/*.*', '!src/static/assets/img/svg/**/*.*'],
		spr: {
			svg: 'src/static/assets/img/sprite/svg/**/*.svg',
			retina2x: 'src/static/assets/img/sprite/retina/2x/*.png',
			default: 'src/static/assets/img/sprite/default/*.png',
		}

	},
	clean: ['dist', 'dist/css/main.css', 'dist/*.html']
};

// Конфиги для локального вебсервера
var webserver = {
	dev: {
		server: {
			baseDir: './dist'
		},
		//tunnel: true,
		//host: 'localhost',
		//port: 9001,
		//logPrefix: 'app_dev'
	},
	prod: {
		server: {
			baseDir: './dist'
		},
		//tunnel: true,
		//host: 'localhost',
		//port: 9002,
		//logPrefix: 'app_prod'
	}
};

// Очистка папок и файлов
gulp.task('clean', function () {
	return gulp.src(path.clean, {
			read: false
		})
		.pipe(clean());
});

//---------------------------------------//
// Компиляция SASS
//---------------------------------------//

//Чистим css
gulp.task('clean:css', function (cb) {
	return gulp.src(path.build.css, {
		read: false
	}).pipe(clean());
});

//development
gulp.task('sass:dev', function () {
	return gulp.src(path.src.sass)
		.pipe(plumber(plumberCfg))
		.pipe(sourcemaps.init())
		.pipe(bulkSass())
		.pipe(sass())
		.pipe(autoprefixer(autoPrefixerOptions))
		.pipe(sourcemaps.write())
		.pipe(gulp.dest(path.build.css));
});

// production
gulp.task('sass:prod', function () {
	return gulp.src(path.src.sass)
		.pipe(plumber(plumberCfg))
		.pipe(bulkSass())
		.pipe(sass({
			outputStyle: 'compressed'
		}))
		.pipe(autoprefixer(autoPrefixerOptions))
		.pipe(gulp.dest(path.build.css));
});

//---------------------------------------//
// Спрайты
//---------------------------------------//

//спрайты
gulp.task('sprite:default', function () {
	var spriteData =
		gulp.src(path.src.spr.default, {
			read: false
		})
		.pipe(plumber(plumberCfg))
		.pipe(spritesmith(spriteDefaultCfg))
	spriteData.img.pipe(gulp.dest(path.build.img)); // путь, куда сохраняем картинку
	spriteData.css.pipe(gulp.dest(path.src.styles)); // путь, куда сохраняем стили
	return spriteData;
});

gulp.task('clean:1x', function (cb) {
	return gulp.src(path.src.spr.retina1x, {
		read: false
	}).pipe(clean());
});

gulp.task('retina:resize', ['clean:1x'], function (cb) {
	var ret = gulp.src(path.src.spr.retina2x)
		.pipe(plumber(plumberCfg))
		.pipe(rename(function (path) {
			path.basename = path.basename.slice(0, -3);
		}))
		.pipe(imageResize(imgResizeCfg))
		.pipe(gulp.dest(path.src.spr.retina1x));

	return ret;
});

gulp.task('sprite:retina', ['retina:resize'], function () {
	var spriteData =
		gulp.src(path.src.spr.retina)
		.pipe(plumber(plumberCfg))
		.pipe(spritesmith(spriteMithRetinaCfg));
	spriteData.img.pipe(gulp.dest(path.build.img));
	spriteData.css.pipe(gulp.dest(path.src.styles));

	return spriteData;
});

gulp.task('sprite:svg', function () {
	gulp.src(path.src.spr.svg)
		.pipe(plumber(plumberCfg))
		.pipe(svgSprite(svgSymbol))
		.pipe(gulp.dest(path.build.svg));
});

//---------------------------------------//
// Оптимизация изображений
//---------------------------------------//
//Чистим pic
gulp.task('clean:pic', function (cb) {
	return gulp.src(path.build.pic, {
		read: false
	}).pipe(clean());
});
gulp.task('img:pic', function () {
	gulp.start('clean:pic');
	gulp.src(path.src.pic)
		// .pipe(imagemin({
		//     progressive: true,
		//     svgoPlugins: [{removeViewBox: false}],
		//     use: [pngquant()],
		//     interlaced: true
		// }))
		.pipe(gulp.dest(path.build.pic));
});
//Чистим img
gulp.task('clean:img', function (cb) {
	return gulp.src(path.build.img, {
		read: false
	}).pipe(clean());
});
var imgTimer;
gulp.task('img:img', function () {
	clearTimeout(imgTimer);
	gulp.start('clean:img');
	imgTimer = setTimeout(function () {
		gulp.start('sprite:retina');
		gulp.start('sprite:default');
		gulp.start('sprite:svg');

		return gulp.src(path.src.img)
			// .pipe(imagemin({
			//     progressive: true,
			//     svgoPlugins: [{removeViewBox: false}],
			//     use: [pngquant()],
			//     interlaced: true
			// }))
			.pipe(gulp.dest(path.build.img));
	}, 300)


});


//---------------------------------------//
// Склеивание скриптов
//---------------------------------------//
gulp.task('scripts:dev', function () {
	return gulp.src(path.src.js)

		.pipe(include({
			hardFail: true,
			includePaths: [
				__dirname + '/',
				__dirname + '/bower_components',
				__dirname + '/node_modules',
				__dirname + '/src/static/scripts/'
			]
		}))
        .pipe(babel({
            presets: ['@babel/env']
        }))
		.pipe(concat('scripts.js'))
		.pipe(removeEmptyLines({
			removeComments: true
		}))
		.pipe(gulp.dest(path.build.js));
});
// 
gulp.task('scripts:build', function () {
	return gulp.src(path.src.js)
		.pipe(include({
			hardFail: true,
			includePaths: [
				__dirname + '/',
				__dirname + '/bower_components',
				__dirname + '/node_modules',
				__dirname + '/src/static/scripts/'
			]
		}))
        .pipe(babel({
            presets: ['@babel/env']
        }))
		.pipe(concat('scripts.js'))
		.pipe(uglify())
		.pipe(gulp.dest(path.build.js));
});
gulp.task('configs:build', function () {
	return gulp.src(path.src.configs)
		.pipe(gulp.dest(path.build.configs));
});

//---------------------------------------//
// Перенос шрифтов
//---------------------------------------//

gulp.task('fonts:build', function () {
	gulp.src(path.src.fonts)
		.pipe(gulp.dest(path.build.fonts))
});

//---------------------------------------//
// Сборка svg html
//---------------------------------------//

gulp.task('clean:svgHtml', function (cb) {
	return gulp.src(path.build.svgHtml, {
		read: false
	}).pipe(clean());
});

gulp.task('svgHtml', function () {

	gulp.src(path.src.svgHtml)
		.pipe(plumber(plumberCfg))
		.pipe(fileinclude(fileIncludeCfg))
		.pipe(gulp.dest(path.build.svgHtml))
});

gulp.task('svgSpriteCompl', gulpsync.sync([
	'sprite:svg',
	'svgHtml'
]))

//---------------------------------------//
// Сборка html
//---------------------------------------//

//Чистим html
gulp.task('clean:html', function (cb) {
	return gulp.src(path.build.html, {
		read: false
	}).pipe(clean());
});

gulp.task('app:prod', function () {
	gulp.src(path.src.app)
		.pipe(gulp.dest(path.build.app))
});
gulp.task('html:dev', function () {

	gulp.src(path.src.html)
		.pipe(plumber(plumberCfg))
		.pipe(fileinclude(fileIncludeCfg))
		.pipe(gulp.dest(path.build.root))

	gulp.src(path.src.svgHtml)
		.pipe(plumber(plumberCfg))
		.pipe(fileinclude(fileIncludeCfg))
		.pipe(gulp.dest(path.build.svgHtml))
});

// production
gulp.task('html:prod', function () {
	gulp.src(path.src.html)
		.pipe(plumber(plumberCfg))
		.pipe(fileinclude(fileIncludeCfg))
		.pipe(replace({
			patterns: [{
				match: /(@@[a-zA-Z_]+)/g,
				replacement: ' '
			}]
		}))
		.pipe(htmltidy({
			indent: true
		}))
		//.pipe(htmlbeautify(formatHTML))
		.pipe(gulp.dest(path.build.root))
});

//---------------------------------------//
// watch
//---------------------------------------//

var sassTimer;
gulp.task('watch', function () {
	watch(path.watch.html, function (event, cb) {
		gulp.start('html:dev');
	});
	watch([path.watch.sass, path.src.modules], function (event, cb) {
		clearTimeout(sassTimer)
		sassTimer = setTimeout(function () {
			gulp.start('sass:dev');
		}, 400);
	});
	watch(path.watch.js, function (event, cb) {
		gulp.start('scripts:dev');
	});
	watch([path.watch.fonts], function (event, cb) {
		gulp.start('fonts:build');
	});
	watch([path.watch.spr.svg], function (event, cb) {
		gulp.start('sprite:svg');
	});
	watch([path.watch.spr.default], function (event, cb) {
		gulp.start('sprite:default');
	});
	watch([path.watch.spr.retina2x], function (event, cb) {
		gulp.start('sprite:retina');
	});
	watch([path.watch.pic], function (event, cb) {
		gulp.start('img:pic');
	});
	watch(path.watch.img, function (event, cb) {
		gulp.start('img:img');
	});
	watch(path.watch.configs, function (event, cb) {
		gulp.start('configs:build');
	});
});


//---------------------------------------//
// сервер
//---------------------------------------//
// development
gulp.task('webserver:dev', function () {
	browserSync([path.build.css, path.build.js, path.build.html, path.build.app], webserver.dev);
});

// production
gulp.task('webserver:prod', function () {
	browserSync(webserver.prod);
});


// Режим разработки
gulp.task('develop', gulpsync.sync([
	'clean:html',
	'clean:css',
	'clean:pic',
	[
		'app:prod',
		'html:dev',
		'sass:dev',
		'img:pic',
		'img:img',
		'fonts:build',
		'scripts:dev',
		'configs:build',
		'sprite:retina',
		'sprite:default',
		'sprite:svg'

	],
	'watch',
	'webserver:dev'
]));

// Режим production
gulp.task('production', gulpsync.sync([
	'clean',
	[
		'app:prod',
		'html:prod',
		'sass:prod',
		'configs:build',
		'img:pic',
		'img:img',
		'fonts:build',
		'scripts:build',
		'sprite:retina',
		'sprite:default',
		'sprite:svg'
	]
]));
gulp.task('default', ['develop']);