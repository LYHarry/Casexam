/*
 Navicat Premium Data Transfer

 Source Server         : 192.168.153.129.PostgreSQL
 Source Server Type    : PostgreSQL
 Source Server Version : 100007
 Source Host           : 192.168.153.129:5432
 Source Catalog        : RpcTestDB
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 100007
 File Encoding         : 65001

 Date: 22/03/2019 18:06:34
*/


-- ----------------------------
-- Table structure for SysRole
-- 系统角色表
-- ----------------------------
DROP TABLE IF EXISTS "public"."SysRole";
CREATE TABLE "public"."SysRole" (
  "ID" int4 NOT NULL DEFAULT nextval('"SysRole_ID_seq"'::regclass),
  "Name" varchar(20) COLLATE "pg_catalog"."default",
  "Remark" varchar(200) COLLATE "pg_catalog"."default",
  "Status" int4 NOT NULL,
  "CreateDate" timestamp(6) NOT NULL
);

COMMENT ON COLUMN "public"."SysRole"."ID" IS '主键ID';
COMMENT ON COLUMN "public"."SysRole"."Name" IS '角色名称';
COMMENT ON COLUMN "public"."SysRole"."Remark" IS '备注';
COMMENT ON COLUMN "public"."SysRole"."Status" IS '状态';
COMMENT ON COLUMN "public"."SysRole"."CreateDate" IS '创建时间';
COMMENT ON TABLE "public"."SysRole" IS '系统角色表';

-- ----------------------------
-- Primary Key structure for table SysRole
-- ----------------------------
ALTER TABLE "public"."SysRole" ADD CONSTRAINT "PK_SysRole" PRIMARY KEY ("ID");



-- ----------------------------
-- Table structure for SysUser
-- 系统管理员用户表
-- ----------------------------
DROP TABLE IF EXISTS "public"."SysUser";
CREATE TABLE "public"."SysUser" (
  "ID" int4 NOT NULL DEFAULT nextval('"SysUser_ID_seq"'::regclass),
  "Name" varchar(20) COLLATE "pg_catalog"."default",
  "Account" varchar(50) COLLATE "pg_catalog"."default",
  "Password" varchar(50) COLLATE "pg_catalog"."default",
  "RoleID" int4 NOT NULL,
  "Status" int4 NOT NULL,
  "CreateDate" timestamp(6) NOT NULL
);

COMMENT ON COLUMN "public"."SysUser"."ID" IS '主键ID';
COMMENT ON COLUMN "public"."SysUser"."Name" IS '用户管理员名称';
COMMENT ON COLUMN "public"."SysUser"."Account" IS '账号';
COMMENT ON COLUMN "public"."SysUser"."Password" IS '密码';
COMMENT ON COLUMN "public"."SysUser"."RoleID" IS '角色ID';
COMMENT ON COLUMN "public"."SysUser"."Status" IS '状态';
COMMENT ON COLUMN "public"."SysUser"."CreateDate" IS '创建时间';
COMMENT ON TABLE "public"."SysUser" IS '系统管理员用户表';

-- ----------------------------
-- Primary Key structure for table SysUser
-- ----------------------------
ALTER TABLE "public"."SysUser" ADD CONSTRAINT "PK_SysUser" PRIMARY KEY ("ID");
