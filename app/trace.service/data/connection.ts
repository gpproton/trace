import 'reflect-metadata';
import { DataSource, DataSourceOptions } from 'typeorm';
import { SnakeNamingStrategy } from 'typeorm-naming-strategies';
import 'dotenv/config';
import { join } from 'path';
import { getConfigValue } from '@root/libs/config';
import { IDataOperation } from './IConnection';

const production = process.env.NODE_ENV === 'production';
const config = getConfigValue(
  'database.operation',
) as unknown as IDataOperation;

const entities = [
  join(__dirname, '../libs/common/src/entity/**/*.entity.{ts,js}'),
  join(__dirname, '../libs/module/src/**/*.entity.{ts,js}'),
];
const migrations = [join(__dirname, '/migrations/*.{ts,js}')];
const subscribers = [join(__dirname, '/subscribers/*.{ts,js}')];

export const dataSourceConfig: DataSourceOptions = {
  type: config.type || 'postgres',
  host: config.host || 'localhost',
  port: config.port || 5432,
  username: config.username || 'trace',
  password: config.password || 'trace',
  database: config.password || 'trace',
  entityPrefix: config.entityPrefix || '',
  migrationsRun: config.synchronize && production,
  migrationsTableName: config.migrationsTableName || 'migrations',
  migrationsTransactionMode: config.migrationsTransactionMode || 'each',
  synchronize: config.synchronize && !production,
  installExtensions: config.installExtensions || true,
  dropSchema: false,
  namingStrategy: new SnakeNamingStrategy(),
  logging: config.logging || true,
  entities,
  migrations,
  subscribers,
  extra: {
    characterSet: 'UTF8',
  },
};

export const dataSource = new DataSource(dataSourceConfig);
