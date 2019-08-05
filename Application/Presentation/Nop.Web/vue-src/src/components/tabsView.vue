<style lang="scss">
.tabs-section {
    height: 100%;
    @include b(tablet) {
        display: block !important;
    }
}
.tabs-main {
    padding: 40px 50px 60px 70px;
    flex: 0 0 auto;
    width: calc(100% - 330px);
    overflow: hidden;
    @include b(tablet) {
        flex: 0 0 100%;
        width: 100%;
        padding: 15px 15px 60px;
    }
}
.tab-pager {
    a {
        font-size: 18px;
        font-weight: 300;
        display: inline-block;
        white-space: nowrap;
        span {
            padding: 0 0 2px;
            border-bottom: 1px solid transparent !important;
        }
        & + a {
            margin-left: 30px;
        }
        &:before,
        &:after {
            content: "";
            width: 12px;
            height: 12px;
            font-size: 18px;
            vertical-align: middle;
            color: currentColor;
            border-style: solid;
            border-width: 1px 1px 0 0;
            background-color: currentColor currentColor transparent transparent;
            display: inline-block;
            transform: rotate(45deg);
        }
        &:before {
            margin-right: 5px;
            transform: rotate(225deg);
        }
        &:after {
            margin-left: 5px;
        }
        &.prev-link:after {
            display: none !important;
        }
        &.next-link:before {
            display: none;
        }
        &:hover {
            span {
                border-bottom-color: currentColor !important;
                font-weight: 700;
            }
        }
    }
}

    .tab-title {
        color: #0e36a4;
        font-size: 24px;
        font-weight: 700;
    }
    .tab-subtitle {
        font-size: 16px;
        color: rgba(20, 60, 169, 0.502);
    }
    .tabs {
        background: #dae2fc;
        border-radius: 20px;
    }

.page-sidebar {
    flex: 0 0 330px !important;
    width: 330px;
    min-width: 280px;
    max-width: 100%;
    background: #fff;
    padding: 40px 70px 200px 20px;
    margin: 0 auto;
    position: relative;
    @include b(tablet) {
        width: 540px;
        padding: 15px 15px 30px;
    }
}
.sidebar__title {
    font-size: 24px;
    color: rgb(28, 28, 28);
    font-weight: bold;
    text-transform: uppercase;
    line-height: 1.2;
    text-align: center;
}
.general-ava {
    margin: 20px auto 0;
    text-align: center;
    .v-badge__badge {
        width: 34px;
        height: 34px;
        bottom: 8px;
        right: 8px;
        box-shadow: 0 0 0 3px #fff;
    }
}
.chat {
    position: absolute;
    left: 20px;
    bottom: 60px;
    cursor: pointer;
    .v-badge__badge {
        background: #fff;
        color: #ffd738;
        height: 32px;
        width: 32px;
        font-size: 24px;
        top: 0;
        right: 0;
    }
    .v-avatar {
        transition: all 0.15s ease-in-out;
        .svg-icon {
            transition: all 0.15s ease-in-out;
        }
        &:hover {
            background: #fff !important;
            .svg-icon {
                transition: all 0.15s ease-in-out;
                fill: #567be1 !important;
            }
        }
    }
    @include b(tablet) {
        left: auto;
        transform: none;
        z-index: 2;
        right: 0;
        bottom: -30px;
        .v-badge__badge {
            height: 16px;
            width: 16px;
            font-size: 10px;
            top: 0;
            right: 0;
        }
    }
}
</style>
