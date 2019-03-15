
/*

Source Server Type    : PostgreSQL
Source Catalog        : NetCoreTestDB
Source Schema         : public

Date: 15/03/2019 09:57:39

*/


-- ----------------------------
-- Table structure for sysrole
-- 系统角色表
-- ----------------------------
DROP TABLE IF EXISTS "public"."sysrole";
CREATE TABLE "public"."sysrole" (
  "ID" int4 NOT NULL DEFAULT nextval('"sysrole_ID_seq"'::regclass),
  "Name" varchar(20) COLLATE "pg_catalog"."default" NOT NULL,
  "Remark" varchar(255) COLLATE "pg_catalog"."default",
  "Status" int2 NOT NULL DEFAULT 0,
  "CreateDate" date NOT NULL
)
;
COMMENT ON COLUMN "public"."sysrole"."ID" IS '主键ID';
COMMENT ON COLUMN "public"."sysrole"."Name" IS '角色名称';
COMMENT ON COLUMN "public"."sysrole"."Remark" IS '备注';
COMMENT ON COLUMN "public"."sysrole"."Status" IS '状态';
COMMENT ON COLUMN "public"."sysrole"."CreateDate" IS '创建时间';
COMMENT ON TABLE "public"."sysrole" IS '系统角色表';

-- ----------------------------
-- Primary Key structure for table sysrole
-- ----------------------------
ALTER TABLE "public"."sysrole" ADD CONSTRAINT "sysrole_pkey" PRIMARY KEY ("ID");


-- ----------------------------
-- Table structure for sysuser
-- 系统管理员用户表
-- ----------------------------
DROP TABLE IF EXISTS "public"."sysuser";
CREATE TABLE "public"."sysuser" (
  "ID" int4 NOT NULL DEFAULT nextval('"sysuser_ID_seq"'::regclass),
  "Name" varchar(20) COLLATE "pg_catalog"."default" NOT NULL,
  "Account" varchar(20) COLLATE "pg_catalog"."default" NOT NULL,
  "Password" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "roleid" int4 NOT NULL DEFAULT 0,
  "Status" int2 NOT NULL DEFAULT 0,
  "CreateDate" date NOT NULL
)
;
COMMENT ON COLUMN "public"."sysuser"."ID" IS '主键ID';
COMMENT ON COLUMN "public"."sysuser"."Name" IS '用户管理员名称';
COMMENT ON COLUMN "public"."sysuser"."Account" IS '账号';
COMMENT ON COLUMN "public"."sysuser"."Password" IS '密码';
COMMENT ON COLUMN "public"."sysuser"."roleid" IS '角色ID';
COMMENT ON COLUMN "public"."sysuser"."Status" IS '状态';
COMMENT ON COLUMN "public"."sysuser"."CreateDate" IS '创建时间';
COMMENT ON TABLE "public"."sysrole" IS '系统管理员用户表';

-- ----------------------------
-- Primary Key structure for table sysuser
-- ----------------------------
ALTER TABLE "public"."sysuser" ADD CONSTRAINT "sysuser_pkey" PRIMARY KEY ("ID");